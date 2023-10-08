using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.DataLoader
{
    internal interface IProcessor
    {
        public void LoadData(string path);
        public void Process(byte[] data);
    }
}
