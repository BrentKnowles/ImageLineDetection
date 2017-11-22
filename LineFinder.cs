using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using Paloma;
namespace ImageLineDetection
{
    /// <summary>
    /// 
    /// </summary>
    class LineFinder : utility
    {
        private Color colorToMatch;
        private int lineThreshold = 0;
        private List<FileInfo> matchFiles;

        public LineFinder(Color ColorToMatch, int LineThreshold)
        {
            colorToMatch = ColorToMatch;
            lineThreshold = LineThreshold;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matchingList"></param>
        /// <param name="notMatchList"></param>
        /// <returns></returns>
        public bool ListFilesMatchingDetection(string FIRST_LOOK_LOCATION, ref List<FileInfo> matchingList, ref List<FileInfo> notMatchList)
        {

            matchFiles = new List<FileInfo>();
            matchFiles = matchingList;


            // Start with drives if you have to search the entire computer.
            /*string[] drives = new string[1] {FIRST_LOOK_LOCATION};// System.Environment.GetLogicalDrives();

            foreach (string dr in drives)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

                // Here we skip the drive if it is not ready to be read. This
                // is not necessarily the appropriate action in all scenarios.
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                System.IO.DirectoryInfo rootDir = di.RootDirectory;
                WalkDirectoryTree(rootDir);
            }*/

            if (!Directory.Exists(FIRST_LOOK_LOCATION))
            {
                Story(String.Format("No Directory with name = {0}", FIRST_LOOK_LOCATION));


            }
            else
            {

                Story("Starting");
                Story(String.Format("Source Directory:{0}", FIRST_LOOK_LOCATION));
                WalkDirectoryTree(new System.IO.DirectoryInfo(FIRST_LOOK_LOCATION));
            }

            // set things back
            matchingList = matchFiles;

            // Write out all the files that could not be processed.

            /*
            Console.WriteLine("Files with restricted access:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
            // Keep the console window open in debug mode.
            // Console.WriteLine("Press any key");
            //Console.ReadKey();
            */


            
            return false;
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fi"></param>
        protected override void DoActionsOnFoundFile(FileInfo fi)
        {
            if (IsValidImage(fi) == true)
            {
                
                if (ScanFileForLineWithColor(fi))
                {
                    Story(String.Format("[MATCH] Adding {0} to Matched List", fi.FullName));
                    // add to found list
                    matchFiles.Add(fi);
                }
                else
                {
                    // add to NotFound list (in the case of line detection this means this is a "good file" because it did not have lines
                    Story(String.Format("[NOT MATCH] Adding {0} to Not-Matched List", fi.FullName));
                }
            }
            // Other criteria (a delegate call here?)
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PATH"></param>
        private  bool ScanFileForLineWithColor(FileInfo fi)
        {
           
            bool returnVal = false;
            int linecount = 0;
            Story("--------------------------------------");
            Story("Start Scan of " + fi.FullName);
            try
            {
                Stopwatch watch = new Stopwatch(); watch.Start();
               // List<Bitmap> l_new, l_old;
                
                {

                    Bitmap bmp = null;

                    if (fi.Extension == ".png")
                    {
                        bmp = Image.FromFile(fi.FullName) as Bitmap;
                    }
                    else if (fi.Extension == ".tga")
                    {
                        TargaImage newImage = new Paloma.TargaImage(fi.FullName);
                        bmp = newImage.Image;
                    }
                    else
                    {
                        Story(String.Format("[ERROR] Extension not supported {0} ", fi.Extension));
                        return false;
                    }
                    

                    // Initialization
                   // l_old = new List<Bitmap>();
                    // l_new = new List<Bitmap>();
                    //l_new.Add(bmp);


                 

                    // Splitting
                    //    while (l_new.Count > l_old.Count)
                    {
                      //  l_old = l_new; l_new = new List<Bitmap>();

                        // l_new.AddRange(SplitBitmapsVertically(SplitBitmapsHorizontally(l_old)));
                        linecount = DetectHorizontalLines(bmp,colorToMatch);

                    }

                    // for (Int32 i = 0; i < l_new.Count; i++)
                    // {
                    //     l_new[i].Save(@"C:\sim\bitmap_" + i + ".bmp");
                    // }
                   // bmp = null;
                    bmp.Dispose();
                }

                watch.Stop();

                Story("Picture analyzed in ".PadRight(59, '.') + " " + watch.Elapsed.TotalSeconds.ToString("#,##0.0000"));
                Story("Lines found ".PadRight(59, '.') + " " + linecount.ToString());





               // l_old = null;
               // l_new = null;
            }
            catch (Exception ex)
            {
                Story("Failed to open this file. Moving on. " + ex.ToString());
            }
            if (linecount > lineThreshold)
            {
                returnVal = true;
            }
            else
            {
                returnVal = false;
            }
            return returnVal;
        }

    }
}
