using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crc32Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = new OpenFileDialog();
            if (d.ShowDialog() != DialogResult.OK)
                return;

            var stream = d.OpenFile();

            textBox4.Text = d.FileName;
            label1.Text = stream.Length.ToString() + " byte";

            var crcExec = new DevExpress.Utils.Zip.Crc32();
            uint crc = crcExec.Calculate(stream);

            textBox1.Text = crc.ToString("X8");
            textBox2.Text = crc.ToString();
            textBox3.Text = ((int)crc).ToString(); ;
        }
    }
}
