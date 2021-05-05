using System;
using System.Collections.Generic;
using System.Text;

namespace Null.AudioSync.Model
{
    public class StartupArgs
    {
        public bool Host = false;
        public bool Sync = false;
        public bool Help = false;
        public string Address = null;
        public string Port = "10001";
    }
}
