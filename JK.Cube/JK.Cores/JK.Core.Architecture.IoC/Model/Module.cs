using JK.Core.Architecture.IoC.Enum;
using JK.Core.Architecture.IoC.Exceptions;
using System;

namespace JK.Core.Architecture.IoC.Model
{
    public class Module
    {
        public Type TypeFrom { get; private set; }
        public Type TypeTo { get; private set; }
        public string InstanceName { get; set; }
        internal RegisterType TypeRegister {  get;  private set; }
        public object Instance { get; private set; }

        public static Module RegisterType(Type typefrom, Type typeTo,string instanceName = null)
        {
            return new Module(Enum.RegisterType.Type, typefrom, typeTo, instanceName);
        }

        public static Module RegisterType<TFrom, TTo>(string instanceName = null) where TTo : TFrom
        {
            return new Module(Enum.RegisterType.Type, typeof(TFrom), typeof(TTo), instanceName);
        }

        public static Module RegisterType<T>(string instanceName = null)
        {
            return new Module(Enum.RegisterType.Type, typeof(T), typeof(T), instanceName);
        }

        public static Module RegisterSingleton<TFrom,TTo >(string instanceName =null) where TTo : TFrom
        {
            return new Module(Enum.RegisterType.Singleton, typeof(TFrom), typeof(TTo), instanceName);
        }

        public static Module RegisterSingleton<T>(string instanceName = null)
        {
            return new Module(Enum.RegisterType.Singleton, typeof(T), typeof(T), instanceName);
        }

        public static Module RegisterInstance<T>(T instance,string instanceName = null)
        {
            return new Module(Enum.RegisterType.Instance, typeof(T), typeof(T), instance, instanceName);
        }

        private Module(RegisterType typeRegister, Type typeFrom, Type typeTo, string instanceName = null)
        {
            if (typeFrom.IsAssignableFrom(typeTo))
            {
                TypeFrom = typeFrom;
                TypeTo = typeTo;
                TypeRegister = typeRegister;
                InstanceName = instanceName;
            }
            else
            {
                throw new InvaidRespectiveTypesException("the types are not corresponding");
            }
        }

        private Module(RegisterType typeRegister, Type typeFrom, Type typeTo,object instance ,string instanceName = null)
        {
            if (typeFrom.IsAssignableFrom(typeTo))
            {
                TypeFrom = typeFrom;
                TypeTo = typeTo;
                TypeRegister = typeRegister;
                InstanceName = instanceName;
                Instance = instance;
            }
            else
            {
                throw new InvaidRespectiveTypesException("the types are not corresponding");
            }         
        }
    }
}