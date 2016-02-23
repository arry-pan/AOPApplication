using System;

namespace AOPAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MonitorAOPAttribute : AOPAttribute
    {
        public MonitorAOPAttribute()
            : base()
        { }
        public MonitorAOPAttribute(string aspectXml)
            : base(aspectXml)
        { }
        protected override AOPProperty GetAOPProperty()
        {
            return new MonitorAOPProperty();
        } 
    }
}
