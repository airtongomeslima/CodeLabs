using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW._0___Core
{
    public static class FolderHelper
    {
        public static void Create(string endereco)
        {
            //if (endereco.Contains("."))
            //{
            //    FileInfo f = new FileInfo(endereco);
            //    endereco = f.Directory.FullName;
            //}

            if (!Directory.Exists(endereco))
            {
                Directory.CreateDirectory(endereco);
            }
        }
    }
}
