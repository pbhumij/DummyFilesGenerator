using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ziroh.Extras
{
    class Program
    {
        static void Main(string[] args)
        {
            //provide the full path of the source file
            TestFile testFile = new TestFile(@"C:\Users\prash\Desktop\10MB.txt");

            //provide the number of files to be generated and the destination folder where it
            //should be generated. Make sure it ends with a '\'
            testFile.CreateDummyFiles(30,@"D:\test\memory\");
        }
    }
}
