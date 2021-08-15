using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StyleBender.TableauModel
{
    public class TbActiontXpath : IXpathRule
    {
        public string XPath => "/workbook/actions/action";

        public string RuleName => "action";

        public Type T => typeof(TbAction);
    }

    public class TbAction : TableauNode
    {
        //public IXpathRule XpathRule { get; set; }
        public XmlNode CurrentXmlNode { get; set; }
        public TbNodeList TableauNodeList { get; set; }

        public TbAction(XmlNode node)
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
