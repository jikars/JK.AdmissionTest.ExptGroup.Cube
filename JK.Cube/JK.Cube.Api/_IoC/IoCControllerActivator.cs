using JK.Core.Architecture.IoC;
using JK.Core.Architecture.IoC.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;

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
            return _container.Resolve(type, type.Name);
        }

#pragma warning disable S1186 // Methods should not be empty
        public void Release(ControllerContext context, object controller)
#pragma warning restore S1186 // Methods should not be empty
        {
        }
    }
}
