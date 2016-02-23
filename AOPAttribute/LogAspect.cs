using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public class LogAspect:Aspect
    {
        public LogAspect(IMessageSink nextSink):base(nextSink)
        { }
    }
}
