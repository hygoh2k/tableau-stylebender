using StyleBender.TableauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StyleBender
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\huany\source\repos\ReportGen\Script\test_output - Copy.twb");
            
            TbWorkbook workbook = new TbWorkbook(doc.CloneNode(true) as XmlDocument);
            workbook.Load();
            var tbact = workbook.GetItems<TbAction>();
            var tbWs = workbook.GetItems<TbWorksheet>();

            var all = workbook.Items.OfType<TbAction>();
        }
    }
}
