using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ABB.SrcML;

namespace NppTransform
{
    public class AllNewQuery : ITransform
    {
        public IEnumerable<XElement> Query(XElement fileUnit)
        {
            var newUses = from use in fileUnit.Descendants(OP.Operator)
                          where use.Value == "new"
                          select use;
            return newUses;
        }

        public XElement Transform(XElement element)
        {
            return element;
        }
    }
}
