using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector 
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method , IInterceptor[] interceptors)
        {
            var classAttibutes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttibutes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttibutes.AddRange(methodAttibutes);

            return classAttibutes.OrderBy(x => x.Priority).ToArray();
        }

    }
}
