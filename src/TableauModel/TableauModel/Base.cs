using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StyleBender.TableauModel
{

    public interface IXpathRule
    {
        string XPath { get;  }
        string RuleName { get;  }

        Type T { get; }

    }

    public interface TableauNode
    {
        //IXpathRule XpathRule { get; set; }

        XmlNode CurrentXmlNode { get; set; }

        TbNodeList TableauNodeList { get; set; }

        void Load();
        

    }

    public  class TbNodeList :  IDisposable
    {
        List<TableauNode> _nodes = new List<TableauNode>();
        public void Dispose()
        {
            _nodes.Clear();
        }

        public void Add(TableauNode item)
        {
            _nodes.Add(item);
        }

        public void RemoveAt(int index)
        {
            _nodes.RemoveAt(index);
        }

        public TableauNode this[int index]
        {
            get { return _nodes[index]; }
            set { _nodes[index] = value; }
        }

        public TableauNode[] Items
        {
            get { return _nodes.ToArray(); }
        }
    }
}
