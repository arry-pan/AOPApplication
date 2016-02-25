using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPAttribute
{
   public enum Advice
    {
       /// <summary>
       /// 切入执行前
       /// </summary>
       Before,
       /// <summary>
       /// 切入执行后
       /// </summary>
       After
    }
}
