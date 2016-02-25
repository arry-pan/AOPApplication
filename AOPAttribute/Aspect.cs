using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace AOPAttribute
{
    public abstract class Aspect : IMessageSink
    {
        private IMessageSink m_NextSink;

        public Aspect(IMessageSink nextSink)
        {
            m_NextSink = nextSink;        
        }
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        public IMessageSink NextSink
        {
            get { return m_NextSink;}
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage call = msg as IMethodCallMessage;
            if(call== null){
                return null;
            }
            string methodName = call.MethodName.ToUpper();
            IBeforeAdvice before = FindBeforeAdvice(methodName);
             if (before != null)
             {
                  before.BeforeAdvice(call);
             }           


            IMessage retMsg = null;
            //BeforeProcess();
            retMsg = m_NextSink.SyncProcessMessage(msg);
            //AfterProcess();
            IMethodReturnMessage reply = retMsg as IMethodReturnMessage;
            IAfterAdvice after = FindAfterAdvice(methodName);
            if (after != null)
            {
                after.AfterAdvice(reply);
            }

            return retMsg;
        }
        private void BeforeProcess()
        {
             //方法调用前的实现逻辑；
        }
        private void AfterProcess()
        {
             //方法调用后的实现逻辑；
        }
        public IBeforeAdvice FindBeforeAdvice(string methodName)
        {
            IBeforeAdvice before;
            lock (this.m_BeforeAdvices)
            {
                before = (IBeforeAdvice)m_BeforeAdvices[methodName];
            }
            return before;
        }
        public IAfterAdvice FindAfterAdvice(string methodName)
        {
            IAfterAdvice after;
            lock (this.m_AfterAdvices)
            {
                after = (IAfterAdvice)m_AfterAdvices[methodName];
            }
            return after;
        }


        private SortedList m_BeforeAdvices = new SortedList();
        private SortedList m_AfterAdvices = new SortedList();
        protected virtual void AddBeforeAdvice(string methodName, IBeforeAdvice before)
        {
            lock (this.m_BeforeAdvices)
            {
                if (!m_BeforeAdvices.Contains(methodName))
                {
                    m_BeforeAdvices.Add(methodName, before);
                }
            }
        }
        protected virtual void AddAfterAdvice(string methodName, IAfterAdvice after)
        {
            lock (this.m_AfterAdvices)
            {
                if (!m_AfterAdvices.Contains(methodName))
                {
                    m_AfterAdvices.Add(methodName, after);
                }
            }
        }

        public void ReadAspect(string aspectXml,string aspectName)
        {
            IBeforeAdvice before = (IBeforeAdvice)Configuration.GetAdvice(aspectXml, aspectName, Advice.Before);
            string[] before_methodNames = Configuration.GetNames(aspectXml, aspectName, Advice.Before);
            //Type type = Type.GetType("AOPAttribute.LogAdvice");
            //IBeforeAdvice before = (IBeforeAdvice)type.Assembly.CreateInstance("AOPAttribute.LogAdvice");
            //string[] before_methodNames = new string[] { "ADD", "SUBSTRACT" };
            foreach (string name in before_methodNames)
            {
                 AddBeforeAdvice(name,before);
            }
            IAfterAdvice after = (IAfterAdvice)Configuration.GetAdvice(aspectXml, aspectName, Advice.After);
            string[] after_methodNames = Configuration.GetNames(aspectXml, aspectName, Advice.After);

            //Type type2 = Type.GetType("AOPAttribute.LogAdvice");
            //IAfterAdvice after = (IAfterAdvice)type2.Assembly.CreateInstance("AOPAttribute.LogAdvice");
            //string[] after_methodNames = new string[] { "ADD", "SUBSTRACT" };
            foreach (string name in after_methodNames)
            {
                 AddAfterAdvice(name,after);
            }   
        }
    }
}
