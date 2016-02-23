using System;
using System.Runtime.Remoting.Messaging;
namespace AOPAttribute
{
    public class LogAOPProperty:AOPProperty
    {
        protected override IMessageSink CreateAspect(IMessageSink nextSink)
        {
            return new LogAspect(nextSink);
        }

        protected override string GetName()
        {
            return "LogAOP";
        }
    }
}
