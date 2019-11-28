using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Shashi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DeleteTopNRows = 2;
            string[] lines = System.IO.File.ReadAllLines("file.txt");
            lines = lines.Skip(DeleteTopNRows).ToArray();
        }
    }
}
