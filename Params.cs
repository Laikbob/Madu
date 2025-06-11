using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Madu
{
    public static class Params
    {
        public static string GetResourcePath(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, "resources", fileName);
        }
    }
}
