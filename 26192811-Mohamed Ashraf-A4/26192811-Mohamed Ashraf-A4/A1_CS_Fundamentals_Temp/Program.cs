using System;
using System.IO;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A1_CS_Fundamentals_Temp
{
    class Program
    {
        // Please use this Template for (A1- C# Fundamentals).
        // And follow the same approach for all other Assignments of (Programming Fundamentals using C#) course.

        static void Main(string[] args)
        {
            T8();


            Console.WriteLine("\n\n");
        }



        #region Helping Functions

        // 'Divide & Conquer' is always the best technique for solving problems.
        // You can always divide your big problem to small problems, and solve each apart.
        // Each small problem can be solved in a separate 'Function'.
        // Then you can gather these Functions to solve your big problem.
        // These 'Helping Functions' are exmaples for such aproach.
        // Feel free to use these two functions and create your own ones to help you solve your bigger problems.

        /// <summary>
        /// Ckecks if the input is numeric ('double') or not.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsDouble(string str)
        {
            return double.TryParse(str, out _);  // Search for 'Output Parameter' and learn how to use it.
        }

        /// <summary>
        /// Forces the user to enter a 'number' as an input.
        /// </summary>
        /// <remarks>
        /// (Defencive Coding)
        /// </remarks>
        /// <returns></returns>
        static double DoubleInput()
        {
            string input = Console.ReadLine();

            while (!IsDouble(input))
            {
                Console.WriteLine("Please, Enter a Valid Number");
                input = Console.ReadLine();
            }

            return double.Parse(input);
        }

        #endregion



        /// <summary>
        /// Write a C# program to create a text file and write the following Text in it, then open the file automatically with coding (Mimicking double-clicking on it).
        /// Text:
        /// “{CurrentDate
        ///} {CurrentTime
        /// },”
        /// “Dear Eng. { YourName },”
        /// “You are doing great so far.”
        /// “Keep it up.”
        /// </summary>
        static void T1()
        {
            #region path
            // Full path with file name
            var path = @"E:\Mohamed\ENGINEERING\KAITECH\test.txt";
            #endregion

            #region write file          
            string[] lines =
            {
            $"{DateTime.Now:yyyy-MM-dd} {DateTime.Now:HH:mm:ss},",
            $"Dear Eng. Mohamed,",
            "You are doing great so far.",
            "Keep it up."
            };            
            File.WriteAllLines(path, lines);
            #endregion

            #region open file            
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            #endregion
        }
        


        /// <summary>
        /// Write a C# program to create a hidden file.
        /// </summary>
        static void T2()
        {
            #region path 
            string path = @"E:\Mohamed\ENGINEERING\KAITECH\test.txt";
            #endregion

            #region create hidden file 
            Directory.CreateDirectory(Path.GetDirectoryName(path));            
            File.WriteAllText(path, string.Empty);            
            File.SetAttributes(path, FileAttributes.Hidden);            
            Console.WriteLine("File written to: " + Path.GetFullPath(path));
            #endregion

            #region open hidden file 
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            #endregion
        }


        /// <summary>
        /// Write a C# program to rename a file.
        /// </summary>
        static void T3()
        {
            #region path            
            string originalPath = @"E:\Mohamed\ENGINEERING\KAITECH\test.txt";

            string newPath = @"E:\Mohamed\ENGINEERING\KAITECH\renamed_test.txt";
            #endregion

            #region Check if original file exists
            if (!File.Exists(originalPath))
            {
                Console.WriteLine("Original file does not exist!");
                return;
            }

            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }
            #endregion

            #region rename file
            File.Move(originalPath, newPath);

            Console.WriteLine($"File renamed successfully to: {Path.GetFullPath(newPath)}");
            #endregion

        }

        /// <summary>
        /// Write a C# program to delete a folder with all of its content (files & sub-folders).
        /// </summary>
        static void T4()
        {
            #region path            
            string Directory_Path = @"E:\Mohamed\ENGINEERING\KAITECH\Directory_test";            
            #endregion

            #region create directory
            Directory.CreateDirectory(Directory_Path);
            for (int i = 0; i < 100; i++)
            {
                string fileName = Path.Combine(Directory_Path, $"Directory_test_{i}.txt");
                File.WriteAllText(fileName, string.Empty);
            }
            #endregion

            #region delete directory and sub files  
            //Directory.Delete(Directory_Path, true);
            #endregion            
        }


        /// <summary>
        /// Write a C# program to copy a folder with all of its content (files & sub-folders) from one location to another location.
        /// </summary>
        static void T5()
        {
            #region path
            string sourceFolder = @"E:\Mohamed\ENGINEERING\KAITECH\Directory_test";
            string destinationFolder = @"E:\Mohamed\ENGINEERING\KAITECH\Directory_test_Copy";
            #endregion

            #region copy folder
            
            if (!Directory.Exists(sourceFolder))
                throw new DirectoryNotFoundException($"Source directory not found: {sourceFolder}");

            
            Directory.CreateDirectory(destinationFolder);

            
            foreach (string filePath in Directory.GetFiles(sourceFolder))
            {
                string fileName = Path.GetFileName(filePath);
                string destFilePath = Path.Combine(destinationFolder, fileName);
                File.Copy(filePath, destFilePath, true); 
            }
            #endregion

            #region copy file
            foreach (string subDir in Directory.GetDirectories(sourceFolder))
            {
                string subDirName = Path.GetFileName(subDir);
                string destSubDir = Path.Combine(destinationFolder, subDirName);
                T5();
            }
            #endregion
        }


        /// <summary>
        /// Write a C# program to get the size of a folder in Mega Bytes.
        /// </remarks>
        static void T6()
        {
            #region path
            string Directory_Path = @"E:\Mohamed\ENGINEERING\KAITECH\DONE";
            #endregion

            #region read folders and files
            if (!Directory.Exists(Directory_Path))
            {
                Console.WriteLine("Folder not found!");
                return;
            }

            long totalSize = 0;

            // Recursive function to accumulate size
            void AccumulateSize(string path)
            {
                // Add all file sizes in current folder
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo fi = new FileInfo(file);
                    totalSize += fi.Length;
                }

                // Recurse into subfolders
                foreach (string dir in Directory.GetDirectories(path))
                {
                    AccumulateSize(dir);
                }
            }
            #endregion

            #region accumulate and display
            AccumulateSize(Directory_Path);

            double sizeInMB = totalSize / (1024.0 * 1024.0);
            Console.WriteLine($"Folder size: {sizeInMB:F2} MB");
            #endregion
        }


        /// <summary>
        /// Write a C# program to get the Last Modification Time for each file & sub-folder & sub-file in a specified folder.
        /// </summary>
        static void T7()
        {
            #region path
            string Directory_Path = @"E:\Mohamed\ENGINEERING\KAITECH\DONE";
            #endregion

            #region recursive function           
            if (string.IsNullOrWhiteSpace(Directory_Path) || !Directory.Exists(Directory_Path))
            {
                Console.WriteLine("Folder not found!");
                return;
            }

            Console.WriteLine($"\nLast Modification Times in: {Directory_Path}\n");

            
            void Traverse(string path)
            {
                Console.WriteLine($"[Folder] {path} => {Directory.GetLastWriteTime(path)}");

                foreach (string file in Directory.GetFiles(path))
                {
                    Console.WriteLine($"   [File] {Path.GetFileName(file)} => {File.GetLastWriteTime(file)}");
                }

                foreach (string subDir in Directory.GetDirectories(path))
                {
                    Traverse(subDir);
                }
            }

            Traverse(Directory_Path);
            #endregion  
        }


        /// <summary>
        /// Write a C# program to get the number of Revit Projects & Families in a Folder.
        /// For Example:
        /// Input: E:\Test Folder
        /// Expected Output:
        /// “This Folder has:”
        /// “3 Revit Projects”
        /// “2 Revit Families”
        /// </summary>
        static void T8()
        {
            #region path
            string Directory_Path = @"E:\Mohamed\ENGINEERING\KAITECH\DONE";
            #endregion

            #region read folder
            if (string.IsNullOrWhiteSpace(Directory_Path) || !Directory.Exists(Directory_Path))
            {
                Console.WriteLine("Invalid folder path!");
                return;
            }

            int projectCount = 0;
            int familyCount = 0;

            // Count all .rvt and .rfa files recursively
            string[] files = Directory.GetFiles(Directory_Path, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".rvt")
                    projectCount++;
                else if (ext == ".rfa")
                    familyCount++;
            }


            #endregion

            #region display results
            Console.WriteLine("\nThis Folder has:");
            Console.WriteLine($"{projectCount} Revit Projects");
            Console.WriteLine($"{familyCount} Revit Families");
            #endregion
        }
    }
}