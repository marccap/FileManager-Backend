using System;
using System.Collections.Generic;
using fm.Model;

namespace fm.Providers
{
    public class FileSystemProvider
    {
        public static IEnumerable<FI> GetFIs(String path, bool listDirectories = true, bool listFiles = true, bool listSystem = false, bool listHidden = false, bool recursive = false)
        {
            var directoryInfo = new System.IO.DirectoryInfo(path);
            var searchOption = recursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;

            if (listDirectories)
            {
                foreach (var fsi in directoryInfo.GetDirectories("*", searchOption))
                {
                    if ((!showHidden && (fsi.Attributes & System.IO.FileAttributes.Hidden) != 0) || (!showSystem && (fsi.Attributes & System.IO.FileAttributes.System) != 0))
                    {
                        continue;
                    }
                    yield return new Directory
                    {
                        Name = fsi.Name,
                        PhysicalPath = fsi.FullName.Replace("\\", "/"),
                        IsDirectory = true,
                        LastModified = fsi.LastWriteTime
                    };
                }
            }
            if (files)
            {
                foreach (var fsi in directoryInfo.GetFiles("*", searchOption))
                {
                    if ((!showHidden && (fsi.Attributes & System.IO.FileAttributes.Hidden) != 0) || (!showSystem && (fsi.Attributes & System.IO.FileAttributes.System) != 0))
                    {
                        continue;
                    }
                    yield return new File
                    {
                        Name = fsi.Name,
                        PhysicalPath = fsi.FullName.Replace("\\", "/"),
                        Length = fsi.Length,
                        IsDirectory = false,
                        LastModified = fsi.LastWriteTime
                    };
                }
            }
        }

        public static void DeleteFI(String path) {
            var di = new System.IO.DirectoryInfo(path);
            if (di.Exists)
            {
                di.Delete();
                return;
            }
            var fi = new System.IO.FileInfo(path);

            if (fi.Exists) {
                fi.Delete();
                return;
            }
        }
    }
}
