using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public class LogAdvice : IAfterAdvice, IBeforeAdvice
    {
        public void BeforeAdvice(IMethodCallMessage callMsg)
        {
            if (callMsg == null)
            {
                return;
            }
            Console.WriteLine("{0}({1},{2})", callMsg.MethodName, callMsg.GetArg(0), callMsg.GetArg(1));
        }

        public void AfterAdvice(IMethodReturnMessage returnMsg)
        {
            if (returnMsg == null)
            {
                return;
            }
            Console.WriteLine("Result is {0}", returnMsg.ReturnValue);
        }
    }
}
