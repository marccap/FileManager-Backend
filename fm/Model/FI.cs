using System;

namespace fm.Model
{
    public class FI
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
        public string PhysicalPath { get; set; }
        public DateTime LastModified { get; set; }
    }
}