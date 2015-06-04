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

        public static void Upload(string folder, string filename, Stream fileStream)
        {
            client.UploadFile(folder, filename, fileStream);
        }

        public static string Download(string path)
        {
            return client.GetMedia(path).Url;
        }
    }
}