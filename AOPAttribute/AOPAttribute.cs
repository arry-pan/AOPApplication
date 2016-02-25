﻿using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Activation;

namespace AOPAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class AOPAttribute : Attribute, IContextAttribute
    {
        private string m_AspectXml;
        private const string CONFIGFILE = @"..\..\configuration\aspect.xml";
        public AOPAttribute()
        {
            m_AspectXml = CONFIGFILE;
        }
        public AOPAttribute(string aspectXml)
        {
            this.m_AspectXml = aspectXml;
        }  
        protected abstract AOPProperty GetAOPProperty();

        public void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
        {
            AOPProperty property = GetAOPProperty();
            property.AspectXml = m_AspectXml;
            ctorMsg.ContextProperties.Add(property);
        }

        public bool IsContextOK(Context ctx, IConstructionCallMessage msg)
        {
            return false;
        }
    }
}
