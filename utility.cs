using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ImageLineDetection
{
    /// <summary>
    /// 
    /// </summary>
    class utility
    {
        protected static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        static long storycount = 0;

        static public void Story(string line)
        {
            // wrapper for Console writing so i can redirect output later
            Console.WriteLine(String.Format("[{0}] "+line, storycount++));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagepath"></param>
        /// <returns></returns>
        protected static bool IsValidImage(FileInfo fi)
        {
            string lowext = fi.Extension.ToLower();
            if (lowext == ".png" || lowext == ".tga" || lowext == ".jpg")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fi"></param>
        protected virtual void DoActionsOnFoundFile(FileInfo fi)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        protected void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Story(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    //Console.WriteLine(fi.FullName);
                    DoActionsOnFoundFile(fi);


                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l_old"></param>
        /// <param name="testColor"></param>
        /// <returns></returns>
        protected static List<Bitmap> SplitBitmapsVertically(List<Bitmap> l_old, Color testColor)
        {
            Int32 x_start = -1; Bitmap bmp; Boolean colContainsData = false;
            List<Bitmap> l = new List<Bitmap>();

            foreach (Bitmap b in l_old)
            {
                for (Int32 x = 0; x < b.Width; x++)
                {
                    colContainsData = false;

                    for (Int32 y = 0; y < b.Height; y++)
                    {
                        if (b.GetPixel(x, y).ToArgb() == testColor.ToArgb())
                        {
                            colContainsData = true;
                        }
                    }

                    if (colContainsData) if (x_start < 0) { x_start = x; }
                    if (!colContainsData || (x == (b.Width - 1)))
                        if (x_start >= 0)
                        {
                            bmp = new Bitmap(x - x_start, b.Height);

                            for (Int32 x_tmp = x_start; x_tmp < x; x_tmp++)
                                for (Int32 y_tmp = 0; y_tmp < b.Height; y_tmp++)
                                {
                                    bmp.SetPixel(x_tmp - x_start, y_tmp, b.GetPixel(x_tmp, y_tmp));
                                }

                            l.Add(bmp); x_start = -1;
                        }
                }
            }

            return l;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="l_old"></param>
        /// <param name="testColor"></param>
        /// <returns></returns>
        protected  static List<Bitmap> SplitBitmapsHorizontally(List<Bitmap> l_old, Color testColor)
        {
            Int32 y_start = -1; Bitmap bmp; Boolean rowContainsData = false;
            List<Bitmap> l = new List<Bitmap>();

            foreach (Bitmap b in l_old)
            {
                for (Int32 y = 0; y < b.Height; y++)
                {
                    rowContainsData = false;

                    for (Int32 x = 0; x < b.Width; x++)
                    {
                        if (b.GetPixel(x, y).ToArgb() == testColor.ToArgb())
                        {
                            rowContainsData = true;
                        }
                    }

                    if (rowContainsData) if (y_start < 0) { y_start = y; }
                    if (!rowContainsData || (y == (b.Height - 1)))
                        if (y_start >= 0)
                        {
                            bmp = new Bitmap(b.Width, y - y_start);

                            for (Int32 x_tmp = 0; x_tmp < b.Width; x_tmp++)
                                for (Int32 y_tmp = y_start; y_tmp < y; y_tmp++)
                                {
                                    bmp.SetPixel(x_tmp, y_tmp - y_start, b.GetPixel(x_tmp, y_tmp));
                                }

                            l.Add(bmp);
                            y_start = -1;
                        }
                }
            }

            return l;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="testColor"></param>
        /// <returns></returns>
        protected  static int DetectHorizontalLines(Bitmap bmp, Color testColor)
        {
            //  Int32 y_start = -1; Bitmap bmp;
            //Boolean rowContainsData = false;
            

            int linesfound = 0;

          //  foreach (Bitmap bmp in l_old)
            {
                for (Int32 y = 0; y < bmp.Height; y++)
                {
                    // rowContainsData = false;
                    

                    for (Int32 x = 0; x < bmp.Width /2; x++) // because we want to catch a LINE, we shouldn't bother to search the full row
                    {
                        
                        if (bmp.GetPixel(x, y).ToArgb() == testColor.ToArgb())
                        {
                            // test middle point
                            if (bmp.GetPixel(bmp.Width / 2, y).ToArgb() == testColor.ToArgb())
                            {
                                //Test End point
                                if (bmp.GetPixel(bmp.Width - 1, y).ToArgb() == testColor.ToArgb())
                                {
                                    linesfound++;
                                    break;
                                }
                            }
                        }
                    }


                }
            }

            return linesfound;
        }
    }
}

