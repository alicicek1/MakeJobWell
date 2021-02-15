using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MakeJobWell.Core.Utilities.Intercepters;

namespace MakeJobWell.BLL.Concrete.DependencyInjection.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }).InstancePerLifetimeScope();

        }
    }
}