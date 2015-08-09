using System.Diagnostics;
using System.IO;

namespace Litle.Sdk.Requests
{
    public class LitleFile
    {
        public virtual string CreateRandomFile(string fileDirectory, string fileName, string fileExtension,
            LitleTime litleTime)
        {
            string filePath;
            if (string.IsNullOrEmpty(fileName))
            {
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                fileName = litleTime.GetCurrentTime("MM-dd-yyyy_HH-mm-ss-ffff_") + RandomGen.NextString(8);
                filePath = fileDirectory + fileName + fileExtension;

                using (new FileStream(filePath, FileMode.Create))
                {
                }
            }
            else
            {
                filePath = fileDirectory + fileName;
            }

            return filePath;
        }

        public virtual string AppendLineToFile(string filePath, string lineToAppend)
        {
            using (var fs = new FileStream(filePath, FileMode.Append))
            using (var sw = new StreamWriter(fs))
            {
                sw.Write(lineToAppend);
            }

            return filePath;
        }
        
        public virtual string AppendFileToFile(string filePathToAppendTo, string filePathToAppend)
        {
            using (var fs = new FileStream(filePathToAppendTo, FileMode.Append))
            using (var fsr = new FileStream(filePathToAppend, FileMode.Open))
            {
                var buffer = new byte[16];
                int bytesRead;

                do
                {
                    bytesRead = fsr.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, bytesRead);
                } while (bytesRead > 0);
            }

            File.Delete(filePathToAppend);
            return filePathToAppendTo;
        }

        public virtual void CreateDirectory(string destinationFilePath)
        {
            var destinationDirectory = Path.GetDirectoryName(destinationFilePath);

            Debug.Assert(destinationDirectory != null, "destinationDirectory != null");
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }
        }
    }
}