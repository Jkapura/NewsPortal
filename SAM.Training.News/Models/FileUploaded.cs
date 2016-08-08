using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace SAM.Training.News.Models
{
    public class FileUploaded
    {
        public HttpPostedFileBase MyFile { get; set; }
        public MemoryStream GetXmlStream()
        {
            using (Stream inputStream = MyFile.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                memoryStream = new MemoryStream();
                inputStream.CopyTo(memoryStream);
                memoryStream.Position = 0;
                return memoryStream;
            }
        }
    }
    
}