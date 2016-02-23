using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public interface IAfterAdvice
    {
        void AfterAdvice(IMethodReturnMessage returnMsg);
    }
}
