using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class FileController : Singleton<FileController>
    {
        private string MyDocumentsDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } }

        private string ClanManegerDirectory { get { return MyDocumentsDirectory + @"\" + "ClanManeger"; } }
        private string ClanInfoDirectory { get { return ClanManegerDirectory + @"\" + "ClanInfo"; } }
        private string BlackListPath { get { return ClanManegerDirectory + @"\" + "BlackList.info"; } }

        public void Init()
        {
            DirectoryInit(ClanManegerDirectory);
            DirectoryInit(ClanInfoDirectory);
            FileInit(BlackListPath);
        }

        public void SaveClanInfo(ClanInfo clanInfo)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
        }

        public string GetBlackListContent()
        {
            return File.ReadAllText(BlackListPath);
        }

        public void SaveBlackListContent(string content)
        {
            File.WriteAllText(BlackListPath, content);
        }

        private void DirectoryInit(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void FileInit(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        private string CompositePath(string path1, string path2)
        {
            string path = path1 + @"\" + path2;
            return path;
        }
    }
}
