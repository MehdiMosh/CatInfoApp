using Autofac;
using System.Reflection;

namespace CatInfoApp.Bootstrap
{
    public static class Bootstrapper
    {
        public static IContainer Container { get; set; }

        public static void ConfigureApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            Container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
