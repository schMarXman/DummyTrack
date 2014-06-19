using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyTrack
{
    /// <summary>
    /// Container class for the combo box.
    /// </summary>
    class LogFile
    {

        public LogFile(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public string Name { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
