using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paloma;
using System.IO;

namespace Brent
{
    public partial class TGAViewer : BrentBaseUserControl
    {
        public TGAViewer()
        {
            InitializeComponent();
        }

        private void fileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileList.SelectedItem == null) return;


            string sFile = fileList.SelectedItem.ToString();
            string ext = new FileInfo(sFile).Extension;
            if (File.Exists(sFile) && ext  == ".tga")
            { 
                pictureBox1.Image = TargaImage.LoadTargaImage(sFile);
            }
            else if (File.Exists(sFile) && ext == ".png")
            {
                pictureBox1.Image = Image.FromFile(sFile);
            }
            else
            {
                MessageBox.Show("Format not supported: " + ext);
            }
        }

        /// <summary>
        /// Paste from clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            fileList.Items.Clear();
            string cliptext = Clipboard.GetText();
            string[] clipped = cliptext.Split(new char[1] { '\n' });
            foreach (string s in clipped)
            {

                string ss = s.Replace("\r", "");
                fileList.Items.Add(ss);
            }
        }
    }
}
