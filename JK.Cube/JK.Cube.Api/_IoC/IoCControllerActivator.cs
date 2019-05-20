using JK.Core.Archytecture.IoC;
using JK.Core.Archytecture.IoC.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JK.Cube.Api
{
    public  class IoCControllerActivator : IControllerActivator
    {
        private readonly IContainer _container;
         
        public IoCControllerActivator()
        {
            _container = IoC.GetInstance();
        } 

        public object Create(ControllerContext context)
        {
            Type type = context.ActionDescriptor.ControllerTypeInfo.AsType();
            List<object> @params = new List<object>();
            var constructor = type.GetConstructors().FirstOrDefault(it => it.IsPublic);
            if (constructor != null)
            {
                foreach (var parameterInfo in constructor.GetParameters())
                {
                    @params.Add(_container.Resolve(parameterInfo.ParameterType));
                }
                object[] paramsObject = @params?.ToArray();

                return Activator.CreateInstance(type, paramsObject != null && paramsObject?.Count() > 0 ? paramsObject : null);
            }
            return null;
        }

#pragma warning disable S1186 // Methods should not be empty
        public void Release(ControllerContext context, object controller)
#pragma warning restore S1186 // Methods should not be empty
        {
        }
    }
}
