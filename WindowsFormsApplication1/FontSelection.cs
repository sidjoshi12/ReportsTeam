using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FontSelection : UserControl
    {
        public FontSelection()
        {
            InitializeComponent();
            initMyFontControl();
        }
        Label[] list;
        FlowLayoutPanel panel;
        private void initMyFontControl()
        {
            list = new Label[FontFamily.Families.Length];
            panel = new FlowLayoutPanel();
            panel.AutoScroll = true;
            panel.Location = new Point(textBox1.Location.X, textBox1.Location.Y + textBox1.Height);
            panel.Width = textBox1.Width;
            panel.Height = 100;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel1.Controls.Add(panel);


            for (int i = 0; i < FontFamily.Families.Length; i++)
            {
                list[i] = new Label();
                try
                {
                    list[i].Font = new Font(FontFamily.Families[i].Name, 10, FontStyle.Regular);
                }
                catch (Exception) { }
                list[i].Text = FontFamily.Families[i].Name;
                list[i].BackColor = Color.White;
                panel.Controls.Add(list[i]);
            }
        }
        private bool _Expand = false;
        public bool Expand
        {
            get
            {
                return _Expand;
            }
            set
            {
                _Expand = value;
                if (_Expand)
                {
                    this.Height += 100;
                    tableLayoutPanel1.Height += 100;
                    panel.Height = 100;
                }
                else
                {
                    this.Height -= 100;
                    tableLayoutPanel1.Height -= 100;
                    panel.Height = 0;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Expand = !Expand;
        }

        private void fontLabel_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.BackColor = SystemColors.MenuHighlight;
        }

        private void fontLabel_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            lab.BackColor = Color.White;
        }
    }
}
