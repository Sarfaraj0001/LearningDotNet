using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LearningDotNet.Models
{
    public class imageClass
    {
        public static string UploadImage(HttpPostedFileBase File, string folderName)
        {
            var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".gif", ".pdf", ".GIF", ".PDF", ".JPG", ".PNG", ".JPEG" };
            return UploadFile(File, folderName, allowedExtensions);
        }

        private static string UploadFile(HttpPostedFileBase File, string folderName, string[] allowedExtensions)
        {
            DateTime dt = DateTime.Now;
            string savedFileName = "" + dt.Year + dt.Month + dt.Day + dt.Hour + dt.Minute + dt.Second + dt.Millisecond + dt.Millisecond + dt.Second + dt.Millisecond + dt.Millisecond + dt.Millisecond + dt.Second + dt.Millisecond + dt.Millisecond + dt.Millisecond;

            string ImageName = Path.GetFileName(File.FileName);


            string ext = Path.GetExtension(ImageName);

            string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/" + folderName + "/" + savedFileName + ext);

            if (!allowedExtensions.Contains(ext))
            {
                return "not allowed";
            }
            File.SaveAs(physicalPath);
            return savedFileName + ext;
        }

        public static bool DeleteFile(string fileNameWithPath)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(fileNameWithPath);
            if (file.Exists)
            {
                file.Delete();
                return true;
            }
            return false;
        }

    }
}