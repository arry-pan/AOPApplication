using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public class MonitorAOPProperty:AOPProperty
    {

        protected override IMessageSink CreateAspect(IMessageSink nextSink)
        {
            return new MonitorAspect(nextSink);
        }

        protected override string GetName()
        {
            return "MonitorAOP";
        }
    }
}
