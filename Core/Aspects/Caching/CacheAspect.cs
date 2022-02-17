using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors.FluentValidation;
using Core.Utilities.IoC;
using Core.CrossCuttingConcerns.Caching;
using System.Linq;

namespace Core.Aspects.Caching
{
    public class CacheAspect: MethodInterception
    {

        ICacheManager _cacheManager;
        private int _duration;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
           

        }
        public override void Intercept(IInvocation invocation)
        {
            //cache için key olusturuluyor.
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))}";

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
