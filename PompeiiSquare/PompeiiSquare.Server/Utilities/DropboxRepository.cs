using DropNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PompeiiSquare.Server.Utilities
{
    public static class DropboxRepository
    {
        private static DropNetClient client;

        static DropboxRepository()
        {
            client = new DropNetClient(AppKeys.DropboxApiKey, AppKeys.DropboxApiSecret, AppKeys.DropboxAccessToken);
        }

        public static string Upload(string fileName, string authorName, Stream fileStream)
        {
            string fullFileName = authorName + "_" + DateTime.Now.ToString("o") + "_" + fileName;
            client.UploadFile("/", fullFileName, fileStream);
            return fullFileName;
        }

        public static string Download(string path)
        {
            return client.GetMedia(path).Url;
        }
    }
}