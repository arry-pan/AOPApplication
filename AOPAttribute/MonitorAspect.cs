using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public class MonitorAspect : Aspect
    {
        public MonitorAspect(IMessageSink nextSink):base(nextSink)
        { }
    }
}
