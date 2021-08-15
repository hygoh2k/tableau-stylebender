using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StyleBender.TableauModel
{
    public class TbWorksheetXpath : IXpathRule
    {
        public string XPath => "/workbook/worksheets/worksheet";

        public string RuleName => "worksheet";

        public Type T => typeof(TbWorkbook);
    }

    public class TbWorksheet : TableauNode
    {
        //public IXpathRule XpathRule { get; set; }
        public XmlNode CurrentXmlNode { get; set; }
        public TbNodeList TableauNodeList { get; set; }

        public TbWorksheet(XmlNode node)
        {
            CurrentXmlNode = node;
        }

        public string Name { get; set; }

        public void Load()
        {
            this.Name = CurrentXmlNode.Attributes["name"].Value;

        }
    }
}
