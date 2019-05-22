using JK.Core.Architecture.IoC.Interface;

namespace JK.Core.Architecture.IoC
{
    public static class IoC
    {
        private static readonly IContainer CONTAINER = new Container();


        public static IContainer GetInstance()
        {
            return CONTAINER;
        }
    }
}
