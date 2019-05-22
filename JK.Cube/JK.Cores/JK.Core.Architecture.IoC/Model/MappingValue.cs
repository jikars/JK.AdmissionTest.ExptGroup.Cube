using JK.Core.Architecture.IoC.Enum;
using System;

namespace JK.Core.Architecture.IoC.Model
{
    internal class MappingValue : ICloneable
    {
        public Type TypeBase { get; private set; }
        public Type TypeResolve { get; private set; }
        public RegisterType TypeRegister {get; internal set; }
        public object Instance { get; internal set; }
        public string InstanceName  { get; private set; }

        public MappingValue(RegisterType typeRegister,Type typeResolve,Type typeBase,string instanceName,object instance = null)
        {
            TypeResolve = typeResolve;
            Instance = instance;
            TypeRegister = typeRegister;
            TypeBase = typeBase;
            InstanceName = instanceName;
        }

        public object Clone()
        {
            MappingValue clone = new MappingValue(TypeRegister, TypeResolve, TypeBase, InstanceName, Instance);
            return clone;
        }
    }
}
