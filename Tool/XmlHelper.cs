using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using PDBWebLibrary.Tool.Log;

namespace PDBWebLibrary.Tool
{
    public static class XmlHelper
    {
        ///<summary>returns the string for xpath. throws exception if not found</summary>
        public static string GetStringRequired(this XPathNavigator navigator, string xpath)
        {
            return GetStringRequiredInner(() => navigator.SelectSingleNode(xpath), xpath);
        }

        ///<summary>returns the string for xpath. throws exception if not found</summary>
        public static string GetStringRequired(this XPathNavigator navigator, string xpath,
                                               IXmlNamespaceResolver manager)
        {
            return GetStringRequiredInner(() => navigator.SelectSingleNode(xpath, manager), xpath);
        }

        ///<summary>returns the string for xpath. throws exception if not found</summary>
        private static string GetStringRequiredInner(Func<XPathNavigator> accessor, string xpath)
        {
            try
            {
                XPathNavigator selectSingleNode = accessor();
                if (selectSingleNode == null)
                {
                    Logger.Instance.Error(String.Format("Unable to parse required string {0} because it is not present in the XML", xpath));
                    throw new ApplicationException(
                        String.Format(
                            "Unable to parse required string from xpath {0} because it is not present in the XML", xpath));
                }
                return selectSingleNode.Value;
            }
            catch (Exception ex)
            {
                Logger.Instance.Info(String.Format("Unable to parse required string {0}. Exception was {1}", xpath, ex.Message));

                throw new ApplicationException(
                    String.Format("Unable to parse required string from xpath {0}. Inner exception {1}", xpath,
                                  ex.Message), ex);
            }
        }
    }
}
