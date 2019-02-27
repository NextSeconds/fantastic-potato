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
        private string PrivateKeyPath { get { return ClanManegerDirectory + @"\" + "key.info"; } }

        public void Init()
        {
            DirectoryInit(ClanManegerDirectory);
            DirectoryInit(ClanInfoDirectory);
            FileInit(BlackListPath);
            FileInit(PrivateKeyPath);
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

        public string GetPrivateKey()
        {
            return File.ReadAllText(PrivateKeyPath);
        }

        public void SavePrivateKey(string key)
        {
            File.WriteAllText(PrivateKeyPath, key);
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
                File.Create(filePath).Close();
            }
        }

        private string CompositePath(string path1, string path2)
        {
            string path = path1 + @"\" + path2;
            return path;
        }
    }
}
