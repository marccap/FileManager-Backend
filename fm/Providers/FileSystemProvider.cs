using System;
using System.Collections.Generic;
using fm.Model;

namespace fm.Providers
{
    public class FileSystemProvider
    {
        public static IEnumerable<FI> GetFIs(String path, bool showSystem = false, bool showHidden = false)
        {
            var directoryInfo = new System.IO.DirectoryInfo(path);

            foreach (var fsi in directoryInfo.GetDirectories())
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
            foreach (var fsi in directoryInfo.GetFiles())
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
}
