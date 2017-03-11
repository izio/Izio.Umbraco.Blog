using System.Web.Hosting;
using System.Xml;
using Izio.Umbraco.ContentUtilities;
using umbraco.interfaces;

namespace Izio.Umbraco.Blog.Installation
{
    /// <summary>
    /// 
    /// </summary>
    public class Setup : IPackageAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Alias()
        {
            return "Blog_Setup";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public bool Execute(string packageName, XmlNode xmlData)
        {
            var templateCreator = new TemplateCreator();
            var contentTypeCreator = new ContentTypeCreator();
            var partialViewCreator = new PartialViewCreator();
            var macroCreator = new MacroCreator();
            var dataTypeCreator = new DataTypeCreator();
            var stylesheetCreator = new StylesheetCreator();

            templateCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            contentTypeCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            partialViewCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            macroCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            dataTypeCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            stylesheetCreator.Deploy(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public bool Undo(string packageName, XmlNode xmlData)
        {
            var templateCreator = new TemplateCreator();
            var contentTypeCreator = new ContentTypeCreator();
            var partialViewCreator = new PartialViewCreator();
            var macroCreator = new MacroCreator();
            var dataTypeCreator = new DataTypeCreator();
            var stylesheetCreator = new StylesheetCreator();

            templateCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            contentTypeCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            partialViewCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            macroCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            dataTypeCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));
            stylesheetCreator.Retract(HostingEnvironment.MapPath("~/App_Plugins/Blog/configuration.xml"));

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlNode SampleXml()
        {
            var sample = new XmlDocument();
            sample.LoadXml(string.Format("<Action runat=\"install\" undo=\"true\" alias=\"{0}\" />", Alias()));

            return sample;
        }
    }
}
