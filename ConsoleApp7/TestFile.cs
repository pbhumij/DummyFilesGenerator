using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;

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
                int fileCount = 2;
                long newFileLength = fs.Length*fileCount;

                for (int i = 0; i < maxFiles; i++)
                {
                    using (FileStream fstream = new FileStream(destinationFolder+fileInfo.Name+i+fileInfo.Extension, FileMode.Create, FileAccess.Write))
                    {
                        fstream.SetLength(newFileLength);
                        
                        for (int j = 0; j < fileCount; j++)
                        {
                            byte[] fileBytes = new byte[fs.Length]; 
                            int bytesRead;
                            fs.Position = 0;
                            while ((bytesRead = fs.Read(fileBytes, 0, (int)fs.Length)) > 0)
                            {
                                fstream.Write(fileBytes, 0, bytesRead);
                                fstream.Flush();
                            }
                            fileBytes = null;
                        }
                    }
                    fileCount++;
                }
            }
        }

      
    }
}
