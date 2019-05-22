using System;

namespace JK.Core.Architecture.IoC.Model
{
    internal class MappingKey
    {
        public Type Type { get; protected set; }
        public string InstanceName { get; protected set; }

        internal MappingKey(Type type, string instanceName)
        {
            Type = type ?? throw new ArgumentNullException("type");
            InstanceName = instanceName;
        }
    }
}
