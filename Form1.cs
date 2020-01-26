using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace cbpsDBjsonPOC {
    public partial class Form1 : Form {
        List<Entry> lb3pl;
        List<Entry> lb1hb;
        List<Entry> lb2pc;

        public Form1() {
            InitializeComponent();
        }
        class Entry {
            public string name = "name";
            public int id = 0;
            public string author = "author";
            public string description = "description";
            public string url = "url";
            public string date = DateTime.Today.ToString("yyyy-MM-dd");
            public string source = "source";
        }

        class jason {
            public List<Entry> lb3json;
            public List<Entry> lb1json;
            public List<Entry> lb2json;
        }

        private void Form1_Load(object sender, EventArgs e) {
            lb3pl = new List<Entry>();
            lb1hb = new List<Entry>();
            lb2pc = new List<Entry>();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        }

        private void Button4_Click(object sender, EventArgs e) {

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.DefaultExt = "json";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    var fileStream = openFileDialog.OpenFile();
                    string filecontent = "";

                    using (StreamReader reader = new StreamReader(fileStream)) {
                        filecontent = reader.ReadToEnd();
                    }
                    lb3pl.Clear();
                    lb1hb.Clear();
                    lb2pc.Clear();
                    jason injason = new jason();
                    injason = JsonConvert.DeserializeObject<jason>(filecontent);
                    lb2pc = injason.lb2json.GetRange(0, injason.lb2json.Count);
                    lb1hb = injason.lb1json.GetRange(0, injason.lb1json.Count);
                    lb3pl = injason.lb3json.GetRange(0, injason.lb3json.Count);
                    listBox3.Items.Clear();
                    for (int i = 0; i < lb3pl.Count; i++) {
                        listBox3.Items.Add(lb3pl[i].name);
                    }
                    listBox1.Items.Clear();
                    for (int i = 0; i < lb1hb.Count; i++) {
                        listBox1.Items.Add(lb1hb[i].name);
                    }
                    listBox2.Items.Clear();
                    for (int i = 0; i < lb2pc.Count; i++) {
                        listBox2.Items.Add(lb2pc[i].name);
                    }
                }
            }
        }

        private void Label7_Click(object sender, EventArgs e) {

        }


        private void Button1_Click(object sender, EventArgs e) {
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB2) {
                int index = listBox3.SelectedIndex;
                lb3pl.Add(new Entry());
                listBox3.Items.Clear();
                for (int i = 0; i < lb3pl.Count; i++) {
                    listBox3.Items.Add(lb3pl[i].name);
                }

                if (lb3pl.Count == 1) {
                    lb3pl[0].id = 0;
                } else {
                    lb3pl[lb3pl.Count - 1].id = lb3pl[lb3pl.Count - 2].id + 1;
                }
                for (int i = 0; i < lb3pl.Count - 1; i++) {
                    while (lb3pl[lb3pl.Count - 1].id <= lb3pl[i].id) {
                        lb3pl[lb3pl.Count - 1].id = lb3pl[lb3pl.Count - 1].id + 1;
                    }
                }
                if (index != -1) {
                    listBox3.SelectedIndex = index;
                }
            }
            if (tab == TAB1) {
                int index = listBox1.SelectedIndex;
                lb1hb.Add(new Entry());
                listBox1.Items.Clear();
                for (int i = 0; i < lb1hb.Count; i++) {
                    listBox1.Items.Add(lb1hb[i].name);
                }
                if (lb1hb.Count == 1) {
                    lb1hb[0].id = 0;
                } else {
                    lb1hb[lb1hb.Count - 1].id = lb1hb[lb1hb.Count - 2].id + 1;
                }
                for (int i = 0; i < lb1hb.Count - 1; i++) {
                    while (lb1hb[lb1hb.Count - 1].id <= lb1hb[i].id) {
                        lb1hb[lb1hb.Count - 1].id = lb1hb[lb1hb.Count - 1].id + 1;
                    }
                }
                if (index != -1) {
                    listBox1.SelectedIndex = index;
                }
            }
            if (tab == TAB3) {
                int index = listBox2.SelectedIndex;
                lb2pc.Add(new Entry());
                listBox2.Items.Clear();
                for (int i = 0; i < lb2pc.Count; i++) {
                    listBox2.Items.Add(lb2pc[i].name);
                }
                if (lb2pc.Count == 1) {
                    lb2pc[0].id = 0;
                } else {
                    lb2pc[lb2pc.Count - 1].id = lb2pc[lb2pc.Count - 2].id + 1;
                }
                for(int i = 0; i < lb2pc.Count - 1; i++) {
                    while(lb2pc[lb2pc.Count - 1].id <= lb2pc[i].id) {
                        lb2pc[lb2pc.Count - 1].id = lb2pc[lb2pc.Count - 1].id + 1;
                    }
                }
                if (index != -1) {
                    listBox2.SelectedIndex = index;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            boxName.Text = "";
            boxAuthor.Text = "";
            boxDesc.Text = "";
            boxIcon.Text = "";
            boxDl1.Text = "";
            boxDl2.Text = "";
            boxSrc.Text = "";
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB2) {
                int index = listBox3.SelectedIndex;
                if (lb3pl.Count != 0 && index != -1) {
                    lb3pl.RemoveAt(index);
                }
                listBox3.Items.Clear();
                for (int i = 0; i < lb3pl.Count; i++) {
                    listBox3.Items.Add(lb3pl[i].name);
                }
                if (index < lb3pl.Count) {
                    listBox3.SelectedIndex = index;
                } else if (lb3pl.Count != 0) {
                    listBox3.SelectedIndex = lb3pl.Count - 1;
                }
            }
            if (tab == TAB1) {
                int index = listBox1.SelectedIndex;
                if (lb1hb.Count != 0 && index != -1) {
                    lb1hb.RemoveAt(index);
                }
                listBox1.Items.Clear();
                for (int i = 0; i < lb1hb.Count; i++) {
                    listBox1.Items.Add(lb1hb[i].name);
                }
                if (index < lb1hb.Count) {
                    listBox1.SelectedIndex = index;
                } else if (lb1hb.Count != 0) {
                    listBox1.SelectedIndex = lb1hb.Count - 1;
                }
            }
            if (tab == TAB3) {
                int index = listBox2.SelectedIndex;
                if (lb2pc.Count != 0 && index != -1) {
                    lb2pc.RemoveAt(index);
                }
                listBox2.Items.Clear();
                for (int i = 0; i < lb2pc.Count; i++) {
                    listBox2.Items.Add(lb2pc[i].name);
                }
                if (index < lb2pc.Count) {
                    listBox2.SelectedIndex = index;
                } else if (lb2pc.Count != 0) {
                    listBox2.SelectedIndex = lb2pc.Count - 1;
                }
            }
        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e) {
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int index = listBox3.SelectedIndex;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB2 && index != -1) {
                boxName.Text = lb3pl[index].name;
                boxAuthor.Text = lb3pl[index].author;
                boxDesc.Text = lb3pl[index].description;
                boxIcon.Text = lb3pl[index].id.ToString();
                boxDl1.Text = lb3pl[index].url;
                boxDl2.Text = lb3pl[index].date;
                boxSrc.Text = lb3pl[index].source;
            }
        }

        private void tabControl1_SelectedIndexChanged(Object sender, EventArgs e) {

            boxName.Text = "";
            boxAuthor.Text = "";
            boxDesc.Text = "";
            boxIcon.Text = "";
            boxDl1.Text = "";
            boxDl2.Text = "";
            boxSrc.Text = "";
            listBox1.SelectedIndex = -1;
            listBox2.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e) {
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int index = listBox2.SelectedIndex;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB3 && index != -1) {
                boxName.Text = lb2pc[index].name;
                boxAuthor.Text = lb2pc[index].author;
                boxDesc.Text = lb2pc[index].description;
                boxIcon.Text = lb2pc[index].id.ToString();
                boxDl1.Text = lb2pc[index].url;
                boxDl2.Text = lb2pc[index].date;
                boxSrc.Text = lb2pc[index].source;
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int index = listBox1.SelectedIndex;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB1 && index != -1) {
                boxName.Text = lb1hb[index].name;
                boxAuthor.Text = lb1hb[index].author;
                boxDesc.Text = lb1hb[index].description;
                boxIcon.Text = lb1hb[index].id.ToString();
                boxDl1.Text = lb1hb[index].url;
                boxDl2.Text = lb1hb[index].date;
                boxSrc.Text = lb1hb[index].source;
            }
        }

        private void Button3_Click(object sender, EventArgs e) {
            string tab = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            int index = -1;
            string TAB1 = tabControl1.TabPages[0].Text;
            string TAB2 = tabControl1.TabPages[1].Text;
            string TAB3 = tabControl1.TabPages[2].Text;
            if (tab == TAB1) {
                index = listBox1.SelectedIndex;
            } else if (tab == TAB3) {
                index = listBox2.SelectedIndex;
            } else if (tab == TAB2) {
                index = listBox3.SelectedIndex;
            }
            string identification = boxIcon.Text;
            identification = Regex.Replace(identification, "[^0-9]", "");
            boxIcon.Text = identification;
            if (tab == TAB1 && index != -1) {
                lb1hb[index].name = boxName.Text;
                lb1hb[index].author = boxAuthor.Text;
                lb1hb[index].description = boxDesc.Text;
                lb1hb[index].id = Int32.Parse(identification);
                lb1hb[index].url = boxDl1.Text;
                lb1hb[index].date = DateTime.Today.ToString("yyyy-MM-dd");
                lb1hb[index].source = boxSrc.Text;
            }
            if (tab == TAB3 && index != -1) {
                lb2pc[index].name = boxName.Text;
                lb2pc[index].author = boxAuthor.Text;
                lb2pc[index].description = boxDesc.Text;
                lb2pc[index].id = Int32.Parse(identification);
                lb2pc[index].url = boxDl1.Text;
                lb2pc[index].date = DateTime.Today.ToString("yyyy-MM-dd");
                lb2pc[index].source = boxSrc.Text;
            }
            if (tab == TAB2 && index != -1) {
                lb3pl[index].name = boxName.Text;
                lb3pl[index].author = boxAuthor.Text;
                lb3pl[index].description = boxDesc.Text;
                lb3pl[index].id = Int32.Parse(identification);
                lb3pl[index].url = boxDl1.Text;
                lb3pl[index].date = DateTime.Today.ToString("yyyy-MM-dd");
                lb3pl[index].source = boxSrc.Text;
            }
            listBox2.Items.Clear();
            for (int i = 0; i < lb2pc.Count; i++) {
                listBox2.Items.Add(lb2pc[i].name);
            }
            if (index < lb2pc.Count) {
                listBox2.SelectedIndex = index;
            } else if (lb2pc.Count != 0) {
                listBox2.SelectedIndex = lb2pc.Count - 1;
            }

            listBox3.Items.Clear();
            for (int i = 0; i < lb3pl.Count; i++) {
                listBox3.Items.Add(lb3pl[i].name);
            }
            if (index < lb3pl.Count) {
                listBox3.SelectedIndex = index;
            } else if (lb3pl.Count != 0) {
                listBox3.SelectedIndex = lb3pl.Count - 1;
            }

            listBox1.Items.Clear();
            for (int i = 0; i < lb1hb.Count; i++) {
                listBox1.Items.Add(lb1hb[i].name);
            }
            if (index < lb1hb.Count) {
                listBox1.SelectedIndex = index;
            } else if (lb1hb.Count != 0) {
                listBox1.SelectedIndex = lb1hb.Count - 1;
            }

        }

        private void Button5_Click(object sender, EventArgs e) {
            jason outjason = new jason();
            outjason.lb3json = lb3pl.GetRange(0, lb3pl.Count);
            outjason.lb1json = lb1hb.GetRange(0, lb1hb.Count);
            outjason.lb2json = lb2pc.GetRange(0, lb2pc.Count);
            string jasons = JsonConvert.SerializeObject(outjason, Formatting.Indented);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    sw.WriteLine(jasons);
            }

        }

        private void BoxIcon_TextChanged(object sender, EventArgs e) {

        }

        private void Label5_Click(object sender, EventArgs e) {

        }
    }
}
