using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LogAOPAttribute : AOPAttribute
    {
        public LogAOPAttribute():base()
        { }

        public LogAOPAttribute(string aspectXml):base(aspectXml)
        { }

        protected override AOPProperty GetAOPProperty()
        {
            return new LogAOPProperty();
        }
    }
}
