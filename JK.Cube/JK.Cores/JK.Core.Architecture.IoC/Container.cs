using JK.Core.Architecture.IoC.Enum;
using JK.Core.Architecture.IoC.Exceptions;
using JK.Core.Architecture.IoC.Interface;
using JK.Core.Architecture.IoC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JK.Core.Architecture.IoC
{
    internal class Container : IContainer
    {
        private readonly Dictionary<MappingKey, MappingValue> _mappings;
        private readonly Dictionary<RegisterType, Func<MappingValue, object>> _mappingTypes;


        internal Container()
        {
            _mappings = new Dictionary<MappingKey, MappingValue>();
            _mappingTypes = new Dictionary<RegisterType, Func<MappingValue, object>>
            {
                { Enum.RegisterType.Type, ResolveInstanceFromType },
                { Enum.RegisterType.Instance, ResolveInstanceFromInstace },
                { Enum.RegisterType.Singleton, ResolveInstanceFromSingleton }
            };
        }

        public bool IsRegistered<T>(string name = null)
        {
            var mappingKey = new MappingKey(typeof(T), name);
            return _mappings.ContainsKey(mappingKey);
        }

        public void RegisterInstance<T>(T instance,string name = null)
        {
            var type = typeof(T);
            Register(Enum.RegisterType.Instance, type, type, name, instance);
        }

        public void RegisterSingleton<TFrom,TTo>(string name = null) where TTo : TFrom
        {
            Register(Enum.RegisterType.Singleton, typeof(TFrom), typeof(TTo), name);
        }

        public void RegisterType<TFrom, TTo>(string name = null) where TTo : TFrom
        {

            Register(Enum.RegisterType.Type, typeof(TFrom), typeof(TTo), name);
        }

        public void RegisterType<T>(string name = null)
        {
            var type = typeof(T);
            Register(Enum.RegisterType.Type,type,type, name);
        }
  

        public T Resolve<T>(string name = null)
        {
            return (T)Resolve(typeof(T), name);
        }

        public object Resolve(Type type, string name = null)
        {
            var mappingKey = new MappingKey(type, name);
            MappingValue mappingValue = null;

            if (!string.IsNullOrEmpty(name))
            {
                var mapping = _mappings.FirstOrDefault(it => it.Key.InstanceName == mappingKey.InstanceName && it.Key.Type == mappingKey.Type).Value;
                mappingValue = mapping;
            }

            if (string.IsNullOrEmpty(name) && _mappings.Any(t => t.Key.Type == mappingKey.Type))
            {
                mappingValue  = _mappings.FirstOrDefault(t=> t.Key.Type == mappingKey.Type).Value;
            }         
            else if(mappingValue == null)
            {
                throw new NotFoundTypeFromResolveException($"Not contain definition registered for {type.Name} {name}");
            }

            if (_mappingTypes.TryGetValue(mappingValue.TypeRegister, out Func<MappingValue, object> funcResult))
            {
                return funcResult.Invoke(mappingValue);
            }

            return null;
        }

        private object ResolveInstanceFromType(MappingValue mappingValue)
        {
            List<object> @params = new List<object>();
            var constructor = mappingValue.TypeResolve.GetConstructors().FirstOrDefault(it => it.IsPublic);
            if (constructor == null)
            {
                throw new TypeToSolveDoesNotContainPublicConstructorException($"Type to solve does not contain a public constructor {mappingValue.TypeResolve.Name}");
            }
            foreach (var parameterInfo in constructor.GetParameters())
            {
                @params.Add(Resolve(parameterInfo.ParameterType));
            }
            object[] paramsObject = @params?.ToArray();
            return Activator.CreateInstance(mappingValue.TypeResolve, paramsObject != null && paramsObject?.Count() > 0 ? paramsObject : null);
        }

        private object ResolveInstanceFromInstace(MappingValue mappingValue)
        {
             return ((MappingValue)mappingValue.Clone()).Instance;
        }

        private object ResolveInstanceFromSingleton(MappingValue mappingValue)
        {
            var mappingKey = new MappingKey(mappingValue.TypeBase, mappingValue.InstanceName);
            if (mappingValue.Instance == null)
            {         
                var mappingVal = (MappingValue)mappingValue.Clone();
                mappingVal.TypeRegister = Enum.RegisterType.Type;
                mappingValue.Instance = ResolveInstanceFromType(mappingVal);
                _mappings[mappingKey] = mappingValue;
             }
            return mappingValue.Instance;
        }

        public IEnumerable<T> ResolveAll<T>(string name = null)
        {
            List<T> response = new List<T>();
            IEnumerable<MappingKey> typesKeys = _mappings.Where(t => t.Key.Type == typeof(T)).Select(it=> it.Key);
            foreach(var typeKey in typesKeys)
            {
                var obj = Resolve(typeKey.Type,typeKey.InstanceName);
                if(obj != null && obj is T)
                {
                    response.Add((T)obj);
                }
            }
            return response;    
        }

        private void Register(RegisterType registerType,Type from, Type to, string instanceName = null, object obj =  null )
        {         
            var mappingKey = new MappingKey(from, instanceName);

            if (!_mappings.ContainsKey(mappingKey))
            {
                var mappingValue = new MappingValue(registerType, to, from, instanceName,obj);
                _mappings.Add(mappingKey, mappingValue);
            }
        }

        public void RegisterModule(IModuleIoC module)
        {
            var modulesRegister = module.Register();
            modulesRegister.ForEach(it => {
                Register(it.TypeRegister, it.TypeFrom, it.TypeTo, it.InstanceName, it.Instance);
            });
        }

        public void RegisterModules(IModuleIoC[] modules)
        {
            foreach(var module in modules)
            {
                RegisterModule(module);
            }
        }

        public void RegisterAssembliesModules(Assembly[] assemblies)
        {
            List<IModuleIoC> modulesIoc = new List<IModuleIoC>();
            var type = typeof(IModuleIoC);
            var modules =  assemblies.SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)?.ToList();
            modules?.ForEach(it=> modulesIoc.Add((IModuleIoC)Activator.CreateInstance(it)));
            RegisterModules(modulesIoc?.ToArray());
        }       
    }
}
