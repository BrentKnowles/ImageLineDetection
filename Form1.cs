using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brent;
using System.IO;


namespace ImageLineDetection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }



       
        private void button1_Click(object sender, EventArgs e)
        {

          
          

          

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTGAVIew_Click(object sender, EventArgs e)
        {
            target.Controls.Clear();
            BrentBaseUserControl tga = new TGAViewer();
            target.Controls.Add(tga);
            tga.Dock = DockStyle.Fill;

        }

        private void buttonScanImages_Click(object sender, EventArgs e)
        {
            target.Controls.Clear();
            BrentBaseUserControl tga = new DetectLines();
            target.Controls.Add(tga);
            tga.Dock = DockStyle.Fill;
        }
        private void CreatePanel(BrentBaseUserControl ctrl)
        {

        }
    }


}
