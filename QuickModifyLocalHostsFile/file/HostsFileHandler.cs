using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuickModifyLocalHostsFile.file
{
    class HostsFileHandler
    {
        private static readonly string HOSTS_FILE_PATH = @"C:\Windows\System32\drivers\etc\hosts";
        private static readonly HostsFileHandler INSTANCE=new HostsFileHandler();

        private HostsFileHandler()
        {
            if (!File.Exists(HOSTS_FILE_PATH))
            {
                File.Create(HOSTS_FILE_PATH).Close();
            }
            RemoveFileReadOnlyIfNecessary(HOSTS_FILE_PATH);
        }

        public static HostsFileHandler GetInstance()
        {
            return INSTANCE;
        }

        public string GetHostsAllString()
        {
            string hosts;
            StreamReader streamReader= new StreamReader(HOSTS_FILE_PATH);
            hosts= streamReader.ReadToEnd();
            streamReader.Close();
            return hosts;
        }

        public void WriteHostsFile(string hostsString)
        {
            StreamWriter streamWriter=  new StreamWriter(HOSTS_FILE_PATH, false);
            streamWriter.Write(hostsString);
            streamWriter.Flush();
            streamWriter.Close();
        }

        private void RemoveFileReadOnlyIfNecessary(string filePath)
        {
            if (File.GetAttributes(filePath).ToString().IndexOf("ReadOnly") != -1)
            {
                File.SetAttributes(filePath, FileAttributes.Normal);
            }
        }
    }
}
