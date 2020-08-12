using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TXTsaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files | *.txt";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var path = openFileDialog1.FileName;
            using (var reader = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    richTextBox1.Text += s+"\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            var path = saveFileDialog1.FileName;
            saveFileDialog1.Filter = "Text files | *.txt";
            saveFileDialog1.Dispose();
            if(!string.IsNullOrEmpty(textBox1.Text))
                if (!File.Exists(path))
                {
                  var myRes =  File.Create(path);
                  myRes.Close();
                }
            using (var Writer = new StreamWriter(new FileStream(path, FileMode.Open)))
            {
                string s = "";
                while (richTextBox2.Text != null)
                { 
                    s += richTextBox2.Text;
                }
                Writer.WriteLine(s);
            }
        }
        internal void Form1_Load(object sender, EventArgs e)
        {
            return;
        }
    }
}
