using Castle.MicroKernel.Registration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StyleBender.TableauModel
{

    public class TbWorkbookXpath : IXpathRule
    {
        public string XPath => "/workbook";

        public string RuleName => "Workbook";

        public Type T => typeof(TbWorkbook);
    }

    

    public class TbWorkbook : TableauNode
    {
        private XmlDocument XmlDoc { get; set; }

        //private string FileName { get; set; }
        public IXpathRule XpathRule { get; set; }

        public IXpathRule[] XpathChildRules { get; set; }
        public XmlNode CurrentXmlNode { get; set; }
        public TbNodeList TableauNodeList { get; set; }

        public TbWorkbook(XmlDocument xml)
        {
            //FileName = filename;
            this.XpathRule = new TbWorkbookXpath();
            this.XpathChildRules = new IXpathRule[] { 
                new TbWorksheetXpath(),
                new TbActiontXpath()
            
            };
            this.XmlDoc = xml;
            RegisterComponents();

        }

        //public IEnumerable<T> GetItems<T>()
        //{
        //    return TableauNodeList.OfType<T>();
        //}
        private Castle.Windsor.WindsorContainer _container;
        private void RegisterComponents()
        {
            //_container.Register(Component.For<TableauNode>()
            //    .ImplementedBy<Worksheet>());

            //_container.Register(Component.For<TableauNode>()
            //    .ImplementedBy<TbAction>());


        }

        Dictionary<Type, TbNodeList> _items = new Dictionary<Type, TbNodeList>();

        public T[] GetItems<T>()
        {
            Type t = typeof(T);
            if (_items.ContainsKey(t))
            {
                return _items[t].Items.OfType<T>().ToArray();
            }

            return new T[] { };
        }

        public TableauNode[] Items
        {
            get { return _items.SelectMany(x => x.Value.Items).ToArray(); }
        }
        
        public void Load()
        {
            //XmlDoc.Load(FileName);
            CurrentXmlNode = XmlDoc;

            

            foreach (var rule in XpathChildRules)
            {
                var found = CurrentXmlNode.SelectNodes(rule.XPath);
                if(rule.RuleName.Equals("worksheet"))
                {

                    foreach(XmlNode node in found)
                    {
                        TbWorksheet ws = new TbWorksheet(node);
                        ws.Load();

                        if (!_items.ContainsKey(typeof(TbWorksheet)))
                        {
                            _items[typeof(TbWorksheet)] = new TbNodeList();
                        }
                        _items[typeof(TbWorksheet)].Add(ws);
                    }
                }

                else if (rule.RuleName.Equals("action"))
                {
                    foreach (XmlNode node in found)
                    {
                        TbAction ws = new TbAction(node);
                        ws.Load();

                        if (!_items.ContainsKey(typeof(TbAction)))
                        {
                            _items[typeof(TbAction)] = new TbNodeList();
                        }
                        _items[typeof(TbAction)].Add(ws);
                    }
                }
            }

        }
    }


}
