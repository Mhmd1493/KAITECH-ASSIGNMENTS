using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.Notifications; // Install from NuGet

namespace TempCleaner
{
    internal class Program
    {
        // Import shell32.dll to register an AppUserModelID
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int SetCurrentProcessExplicitAppUserModelID(string appID);

        static void Main(string[] args)
        {
            // Step 1: Register AppID
            SetCurrentProcessExplicitAppUserModelID("KAITECH.TempCleaner");

            // Step 2: Get user temp folder dynamically
            string tempPath = Path.GetTempPath();

            if (!Directory.Exists(tempPath))
            {
                Console.WriteLine("Temp folder not found for the current user!");
                return;
            }

            // Step 3: Calculate initial size
            long beforeSize = GetFolderSize(tempPath);

            // Step 4: Delete files & subfolders, if the code fails exit with the catch clause and do nothing
            try
            {
                DirectoryInfo di = new DirectoryInfo(tempPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    try { file.Delete(); } catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try { dir.Delete(true); } catch { }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cleaning temp: {ex.Message}");
            }

            // Step 5: Calculate size difference
            long afterSize = GetFolderSize(tempPath);
            long freedSize = beforeSize - afterSize;

            // Step 6: Get free space on C: drive
            DriveInfo cDrive = new DriveInfo("C");
            long freeSpace = cDrive.AvailableFreeSpace;

            // Step 7: Format sizes
            string freedText = FormatSize(freedSize);
            string freeText = FormatSize(freeSpace);

            // Step 8: Send notification with skipped info
            new ToastContentBuilder()
                .AddText("🧹 Temp Cleaner")
                .AddText($"Deleted files: {freedText}")
                //.AddText($"Skipped files: {FormatSize(skippedSize)}") // new line
                .AddText($"Free space on C: {freeText}")
                .AddInlineImage(new Uri(Path.GetFullPath(".\\KAITECH Logo.png")))
                .Show();

            Console.WriteLine("Cleaning complete. Press any key to exit...");
            Console.ReadKey();
        }

        // Helper to calculate folder size
        private static long GetFolderSize(string path)
        {
            long total = 0;
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles("*", SearchOption.AllDirectories))
                {
                    total += file.Length;
                }
            }
            catch { }
            return total;
        }

        // Helper to format sizes dynamically
        private static string FormatSize(long bytes)
        {
            double size = bytes;
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            int unitIndex = 0;

            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return $"{size:F2} {units[unitIndex]}";
        }
    }
}
