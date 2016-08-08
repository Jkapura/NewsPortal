using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
namespace SAM.Training.News.Helpers
{
    public class XMLHelper
    {
        public XmlReaderSettings settings { get; set; }
        public XmlSchemaSet schemas { get; set; }

        public XMLHelper(string pathToFile)
        {
            settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            schemas = new XmlSchemaSet();
            schemas.Add(null, new XmlTextReader(pathToFile)); 
            settings.Schemas = schemas;
            
        }
        public void ValidateXml(Stream stream)
        {
            XmlReader reader = XmlReader.Create(stream, settings);
            XmlDocument document = new XmlDocument();
            document.Load(reader);
            XPathNavigator navigator = document.CreateNavigator();
            ValidationEventHandler validation = new ValidationEventHandler(SchemaValidationHandler);
            navigator.MoveToChild("grid", null);
            //XmlWriter writer = navigator.InsertAfter();
            navigator.MoveToChild("article", null);
            navigator.MoveToChild("id", null);
            navigator.MoveToChild("head", null);
            navigator.MoveToChild("date", null);
            navigator.MoveToChild("categoryName", null);
            navigator.MoveToChild("authorName", null);
            document.Validate(validation);
        }

        private void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}