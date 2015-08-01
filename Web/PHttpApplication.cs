using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PDBWebLibrary.Database.Install;
using PDBWebLibrary.Tool.Log;

namespace PDBWebLibrary.Web
{
    public class PHttpApplication : HttpApplication
    {
        public bool IsFirstRequestAfterAppStart { get; set; }

        public static DatabaseSettingsManager DatabaseSettingsManager { get; set; }

        /// <summary>
        /// Invoked on application start. Sets debugmode and application build versions. Initializes the AppPath and the WebLibrary.
        /// Invokes the overridable OnApplicationStart
        /// </summary>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public void Application_Start(object sender, EventArgs e)
        {

            try
            {
                IsFirstRequestAfterAppStart = true;
                AppPath.PhysicalPath = Server.MapPath("~");

                DatabaseSettingsManager = new DatabaseSettingsManager("/settings/settings.xml");

                OnApplicationStart();
            }
            catch (Exception exception)
            {
                Logger.Instance.Error("Application_Start", exception);
                throw;
            }
        }


        /// <summary>
        /// Invoked at the end of Application_Start
        /// </summary>
        protected virtual void OnApplicationStart()
        {
        }
    }
}
