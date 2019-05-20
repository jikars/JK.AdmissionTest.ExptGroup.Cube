using JK.Core.Archytecture.IoC;
using System;

namespace JK.Cube.Api._IoC
{
    public static class IoCBoostrapper
    {
        public static void RegisterModules()
        {
            IoC.GetInstance().RegisterAssembliesModules(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
