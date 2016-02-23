using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public interface IBeforeAdvice
    {
        void BeforeAdvice(IMethodCallMessage callMsg);
    }
}
