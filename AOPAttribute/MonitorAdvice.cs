using System;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public class MonitorAdvice : IBeforeAdvice, IAfterAdvice
    {
        #region IBeforeAdvice Members
        public void BeforeAdvice(IMethodCallMessage callMsg)
        {
            if (callMsg == null)
            {
                return;
            }
            Console.WriteLine("Before {0} at {1}", callMsg.MethodName, DateTime.Now);
        }
        #endregion

        #region IAfterAdvice Members
        public void AfterAdvice(IMethodReturnMessage returnMsg)
        {
            if (returnMsg == null)
            {
                return;
            }
            Console.WriteLine("After {0} at {1}", returnMsg.MethodName, DateTime.Now);
        }
        #endregion
    }
}
