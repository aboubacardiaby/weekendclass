using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.DataLoader
{
    public class Processor : IProcessor
    {
        public void LoadData(string sourceFileLocation)
        {
            DirectoryInfo selectedDirectory = new DirectoryInfo(sourceFileLocation);

            if (!selectedDirectory.Exists)
            {

                return;
            }

            if (!Path.IsPathRooted(sourceFileLocation))
            {

                return;
            }
        }

        public void Process(byte[] data)
        {
            throw new NotImplementedException();
        }
        public void Execute(string _sourceFileLocation)
        {
            DateTime start = DateTime.Now;

            DirectoryInfo selectedDirectory = new DirectoryInfo(_sourceFileLocation);

            if (!selectedDirectory.Exists)
            {

                return;
            }

            if (!Path.IsPathRooted(_sourceFileLocation))
            {

                return;
            }
        }
    }
}
