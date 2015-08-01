using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using PDBWebLibrary.Tool;
using PDBWebLibrary.Tool.Log;
using PDBWebLibrary.Web;

namespace PDBWebLibrary.Database.Install
{
    public class DatabaseSettingsManager
    {
        public string Path { get; set; }

        public string ConnectionString { get; set; }

        public DatabaseSettingsManager(string relativePath)
        {
            Path = AppPath.PhysicalPath + "/"  + relativePath;
            LoadSettings();
        }

        private void LoadSettings()
        {
            var doc = new XmlDocument();

            //if (!File.Exists(Path)) throw new Exception("Config file not found: " + Path);

            try
            {
                using (FileStream textReader = File.OpenRead(Path))
                {
                    XPathNavigator navigator = new XPathDocument(textReader).CreateNavigator();

                    LoadConfig(navigator);
                }
            }
            catch (IOException ex)
            {
                Logger.Instance.Error("Error loading settings",ex);
            }
        }

        private void LoadConfig(XPathNavigator navigator)
        {
            ConnectionString = navigator.GetStringRequired("/settings/connectionstring");
        }
    }
}

