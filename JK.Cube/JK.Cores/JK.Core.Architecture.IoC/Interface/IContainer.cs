using System;
using System.Collections.Generic;
using System.Reflection;

namespace JK.Core.Architecture.IoC.Interface
{
    public interface IContainer
    {
        object Resolve(Type type,string name = null);
        T Resolve<T>(string name = null);
        IEnumerable<T> ResolveAll<T>(string name = null);
        void RegisterType<T>(string name = null);
        void RegisterType<TFrom, TTo>(string name = null) where TTo : TFrom;
        void RegisterInstance<T>(T instance, string name = null);
        void RegisterSingleton<TFrom, TTo>(string name = null) where TTo : TFrom;
        void RegisterModule(IModuleIoC module);
        void RegisterModules(IModuleIoC[] modules);
        void RegisterAssembliesModules(Assembly[] assemblies);

    }
}
