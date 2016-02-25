using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AOPAttribute
{
    public class Configuration
    {
        public static object GetAdvice( string aspectXml,string aspectName, Advice advice)
        {
            
           XElement adviceElm = GetAdviceElement(aspectXml, aspectName, advice);

           string strclass = adviceElm.Attribute("class").Value;

           Type type = Type.GetType(strclass);
           object obj = type.Assembly.CreateInstance(strclass);

           return obj;
        }

        public static string[] GetNames(string aspectXml, string aspectName, Advice advice)
        {
            List<string> list = new List<string>();
            XElement adviceElm = GetAdviceElement(aspectXml, aspectName, advice);

            IEnumerable<XElement> elements = adviceElm.Elements("pointcut");

            foreach (var e in elements)
            {
                list.Add(e.Value);
            }

            return list.ToArray();
        }

        private static XElement GetAdviceElement(string aspectXml, string aspectName, Advice advice)
        {
             XElement root = XElement.Load(aspectXml);

             XElement aspectNote = root.Elements("aspect").First(e => e.Attribute("value").Value.Equals(aspectName, StringComparison.InvariantCultureIgnoreCase));

             //var aspectNotes = from e in root.Elements("aspect")                               
             //                  where e.Attribute("value").Value.Equals(aspectName, StringComparison.InvariantCultureIgnoreCase)
             //                   select  e;

             //XElement aspectNote = aspectNotes.FirstOrDefault();

             XElement adviceNote = aspectNote.Elements("advice").First(e => e.Attribute("type").Value == advice.ToString().ToLower());

             return adviceNote; //xe.Elements("advice").First(e => e.Attribute("type").Value == advice.ToString().ToLower());
        }
    }
}
