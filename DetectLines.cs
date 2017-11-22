using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageLineDetection;
using System.IO;


namespace Brent
{
    public partial class DetectLines : BrentBaseUserControl
    {
        private string PATH = @"D:\Users\Brent\Documents\visual studio 2015\Projects\ImageLineDetection\images\";
        public DetectLines()
        {
            InitializeComponent();
            label2.Text = PATH;
            panel1.BackColor = colorDialog1.Color;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            /// - Five lines?
            LineFinder lineFinder = new LineFinder(colorDialog1.Color, (int)numberoflinespicker.Value);

            List<FileInfo> goodList = new List<FileInfo>();
            List<FileInfo> badList = new List<FileInfo>();

            this.Cursor = Cursors.WaitCursor;


            lineFinder.ListFilesMatchingDetection(PATH, ref badList, ref goodList);

            LineFinder.Story("Matched Files");
            // Dirty Output
            List<string> tmp = new List<string>();

            foreach (FileInfo fi in badList)
            {
                tmp.Add(fi.FullName);
                
            }
            //Console.WriteLine(fi.FullName);
            output.Lines = tmp.ToArray();

            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.SpecialFolder f = new Environment.SpecialFolder();
            //(@"D:\Users\Brent\Documents\visual studio 2015\Projects\ImageLineDetection\images\");
            // folderBrowserDialog1.RootFolder = (Environment.SpecialFolder.MyDocuments);
            folderBrowserDialog1.SelectedPath = @"D:\Users\Brent\Documents\visual studio 2015\Projects\ImageLineDetection\images\";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                PATH = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }
    }
}
