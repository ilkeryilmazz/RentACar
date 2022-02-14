using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
   public class MethodInterception:MethodInterceptionBaseAttribute
   {
       protected virtual void OnBefore(IInvocation invocation){}
       protected virtual void OnExpection(IInvocation invocation,Exception e){}
       protected virtual void OnSuccess(IInvocation invocation){}
       protected virtual void OnAfter(IInvocation invocation){}

       public override void Intercept(IInvocation invocation)
       {
           var isSuccess = true;
           OnBefore(invocation);
           try
           {
               invocation.Proceed();
           }
           catch (Exception e)
           {
               isSuccess = false;
               OnExpection(invocation, e);
               throw;
           }
           finally
           {
               if (isSuccess)
               {
                   OnSuccess(invocation);

               }
           }
           OnAfter(invocation);
       }
   }
}
