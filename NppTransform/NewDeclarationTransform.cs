using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ABB.SrcML;

namespace NppTransform
{
    public class NewDeclarationTransform : ITransform
    {
        public IEnumerable<XElement> Query(XElement fileUnit)
        {
            var newUses = from use in fileUnit.Descendants(OP.Operator)
                          where use.Value == "new"
                          let parent = use.ParentStatement()
                          where parent.Name == SRC.DeclarationStatement
                          select parent;
            return newUses;
        }

        public XElement Transform(XElement element)
        {
//            var declaration = element.Value.Split('=')[0] + ";";
//            element.Element(SRC.Declaration).Element(SRC.Type).Remove();
//            var variableName = element.Value.Split('=')[0];
            

//            var code = @"{0}
//try {{
//    {1}
//}} catch(...) {{
//    {2} = NULL;            
//}}";
//            var tryBlock = new XElement(SRC.Try, string.Format(code, declaration, element.Value, variableName));
//            return tryBlock;
            return element;
        }
    }
}
