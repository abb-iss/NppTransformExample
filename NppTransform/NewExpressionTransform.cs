using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ABB.SrcML;

namespace NppTransform
{
    public class NewExpressionTransform : ITransform
    {
        public IEnumerable<XElement> Query(XElement fileUnit)
        {
            var newUses = from use in fileUnit.Descendants(OP.Operator)
                          where use.Value == "new"
                          let parent = use.ParentStatement()
                          where parent.Name == SRC.ExpressionStatement
                          select parent;
            return newUses;
        }

        public XElement Transform(XElement element)
        {
            var variableName = element.Value.Split('=')[0];

            var code =
@"try {{
    {0}
}} catch(...) {{
    {1} = NULL;
}}";
            var tryCatchBlock = new XElement(SRC.Try, string.Format(code, element.Value, variableName));
            return tryCatchBlock;
            //return element;
        }
    }
}
