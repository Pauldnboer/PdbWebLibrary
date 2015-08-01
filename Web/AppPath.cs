using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace PDBWebLibrary.Web
{
    public static class AppPath
    {
        /// <summary>
        /// The fullpath to the physical root of the webapplication.
        /// </summary>
        public static string PhysicalPath;

        /// <summary>
        /// Returns the virtual path of this application or an empty string
        /// if there is none
        /// </summary>
        public static string VirtualPath
        {
            get
            {
                return (HttpRuntime.AppDomainAppVirtualPath == "/")
                           ? ""
                           : HttpRuntime.AppDomainAppVirtualPath;
            }
        }


        /// <summary>
        /// Returns this requests' current path including the filename
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string RelativePath(HttpRequest request)
        {
            return request.Path.Substring(VirtualPath.Length);
        }

        /// <summary>
        /// Returns this requests' current path without filename
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string RelativeFolderPath(HttpRequest request)
        {
            string path = RelativePath(request);
            return (path.IndexOf('/') == -1)
                       ? path
                       : path.Substring(0, path.LastIndexOf('/') + 1);
        }
    }
}
