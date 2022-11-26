using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Utilities.Helpers
{
    public static class RandomValueGenerator
    {
        public static string FileName(string extension)
        {
            string fileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + DateTime.Now.ToShortDateString().Replace(".", "") + extension;

            return fileName;

            //D76956A78B8747F59A904CD6D974D3AF_05092020.jpg

        }
    }
}
