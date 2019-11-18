using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace WindowsFormsApplication1
{
    public class XPictureBox : PictureBox
    {
        ContextMenuStrip con = new ContextMenuStrip();
        public XPictureBox()
        {
            this.BackColor = Color.Gray;
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Height = 200;
            this.Width = 200;

            ShowContextMenu();
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (this.Image != null)
                {

                }
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                    this.ContextMenuStrip = null;
                else
                    this.ContextMenuStrip = con;

            }
        }
        public Label Caption { get; set; }
        public void ShowContextMenu()
        {

            con.Items.Add("Save As", WindowsFormsApplication1.Properties.Resources.save, con_SaveAsClick);
            con.Items.Add("Change Picture", WindowsFormsApplication1.Properties.Resources.edit, con_ChangePicClick);
            con.Items.Add("Remove Picture", WindowsFormsApplication1.Properties.Resources.cancel, con_RemovePicClick);
            con.Items.Add("Capture From WebCam", WindowsFormsApplication1.Properties.Resources.camera, con_CaptureFromWebCamClick);
            //con.MenuItems.Add("Delete",con_DeletePicClick).Enabled = false;

        }
        public void con_CaptureFromWebCamClick(object sender, EventArgs e)
        {

        }
        public void con_SaveAsClick(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                SaveFileDialog sav = new SaveFileDialog();
                sav.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                sav.Title = "Save an Image File";
                sav.ShowDialog();

                if (sav.FileName != "")
                {
                    System.IO.FileStream fs = (FileStream)sav.OpenFile();
                    //                Saves the Image in the appropriate ImageFormat based upon the
                    //                File type selected in the dialog box.
                    //                NOTE that the FilterIndex property is one-based.
                    switch ((sav.FilterIndex))
                    {

                        case 1:
                            this.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 2:
                            this.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case 3:
                            this.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }
                    fs.Close();
                }
            }
            else
            {
                DialogResult d = MessageBox.Show("No Image to Save.\\n Do you want to Add Image?", "Error", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (d == DialogResult.Yes)
                {
                    con_ChangePicClick(sender, e);
                }
            }
        }
        public void con_RemovePicClick(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                DialogResult d = MessageBox.Show("Are you want to Remove Image?", "Delete Image", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    this.Image = null;
                }
            }
        }
        public void con_DeletePicClick(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you want to Delate This Control?", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                Form f = FindForm();
                f.Controls.Remove(this);
                this.Dispose();
            }
        }
        public void con_ChangePicClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            //op.ShowDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                this.ImageLocation = op.FileName;
            }
        }
        public byte[] ConvertImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public byte[] DataSource
        {
            get
            {
                if (this.Image != null)
                    return ConvertImageToByteArray(this.Image);
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    MemoryStream ms = new MemoryStream(value);
                    this.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                    this.Image = null;

            }
        }

    }
}
