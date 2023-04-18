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

namespace AddMailPass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            od.InitialDirectory = Environment.CurrentDirectory;
            if (od.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> rezultf = new List<string>();
            List<string> infile = new List<string>(File.ReadAllLines(od.FileName));
            od.InitialDirectory = Environment.CurrentDirectory;
            if (od.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            List<string> mailfile = new List<string>(File.ReadAllLines(od.FileName));
            foreach (var item in infile)
            {
                string mail = item.Split(';')[0];
                string mailpasspoop3 = item.Split('|')[3];
                richTextBox1.AppendText(mail+Environment.NewLine);
                richTextBox1.AppendText(mailpasspoop3 + Environment.NewLine);
                foreach (var fullmail in mailfile)
                {
                    if (fullmail.Split(':')[0]==mail)
                    {
                        string mailpassweb = fullmail.Split(':')[1];
                        rezultf.Add(item.Replace(mailpasspoop3,mailpassweb+'|'+mailpasspoop3));
                        break;
                    }
                }
                //return;
            }
            File.WriteAllLines("result.txt",rezultf);
        }
    }
}
