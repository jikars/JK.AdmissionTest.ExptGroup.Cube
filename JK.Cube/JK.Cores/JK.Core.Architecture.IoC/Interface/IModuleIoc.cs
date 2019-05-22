using JK.Core.Architecture.IoC.Model;
using System.Collections.Generic;

namespace JK.Core.Architecture.IoC.Interface
{
    public interface IModuleIoC
    {
       List<Module> Register();
    }
}
