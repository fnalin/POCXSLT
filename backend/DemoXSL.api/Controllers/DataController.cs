using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace DemoXSL.api.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IHostingEnvironment _env;
        public DataController(IHostingEnvironment env)
        {
            _env = env;
        }
        

        [HttpGet]
        public string Get()
        {
            //http://www.c-sharpcorner.com/UploadFile/manas1/display-xml-data-as-html-using-xslt-in-Asp-Net/

            var relatorio = string.Empty;
            var xsltPath = $"{_env.WebRootPath}\\data\\file1.xsl";
            var xmlPath = $"{_env.WebRootPath}\\data\\file1.xml";

            // Creating XSLCompiled object    
            XslCompiledTransform objXSLTransform = new XslCompiledTransform();
            objXSLTransform.Load(xsltPath);

            // Creating StringBuilder object to hold html data and creates TextWriter object to hold data from XslCompiled.Transform method    
            StringBuilder htmlOutput = new StringBuilder();
            TextWriter htmlWriter = new StringWriter(htmlOutput);

            // Creating XmlReader object to read XML content    
            using (XmlReader reader = XmlReader.Create(xmlPath))
            {
                // Call Transform() method to create html string and write in TextWriter object.    
                objXSLTransform.Transform(reader, null, htmlWriter);
                relatorio = htmlOutput.ToString();
            }

            return relatorio;
        }

    }

}
