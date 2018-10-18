using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ziroh.Extras
{
    class TestFile
    {
        string _filePath = null;
        FileInfo fileInfo = null;
        public TestFile(string filePath)
        {
            this._filePath = filePath;
            this.fileInfo = new FileInfo(filePath);
        }

        public void CreateDummyFiles(int maxFiles, string destinationFolder)
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open,FileAccess.Read))
            {
                int offset = 0;
                int newFileLength = (int)fs.Length;
                int fileCount = 2;

                for (int i = 0; i < maxFiles; i++)
                {
                    using (FileStream fstream = new FileStream(destinationFolder+fileInfo.Name+i+fileInfo.Extension, FileMode.Create, FileAccess.Write))
                    {
                        fstream.SetLength(newFileLength*fileCount);
                        byte[] fileBytes = new byte[newFileLength*fileCount];

                        int newOffset = 0;
                        for (int j=0; j < fileCount; j++)
                        {
                            int bytesRead;
                            fs.Position = 0;
                            while ((bytesRead = fs.Read(fileBytes, 0, (int)fs.Length))>0)
                            {
                                fstream.Write(fileBytes, 0, bytesRead);
                                fstream.Flush();
                            }
                        }
                    }
                    fileCount++;
                }
            }
        }
    }
}
