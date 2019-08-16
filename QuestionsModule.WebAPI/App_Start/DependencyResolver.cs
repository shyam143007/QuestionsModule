using Autofac;
using Autofac.Integration.WebApi;
using QuestionsModule.DataModel;
using QuestionsModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace QuestionsModule.WebAPI.App_Start
{
    public static class DependencyResolver
    {
        public static void Register()
        {
            Initialize(GlobalConfiguration.Configuration, RegisterServices(new ContainerBuilder()));
        }

        private static void Initialize(HttpConfiguration configuration, IContainer container)
        {
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            containerBuilder.RegisterType<QuestionsRepository>().As<IQuestionsRepository>().InstancePerRequest();
            containerBuilder.RegisterType<OptionsRepository>().As<IOptionsRepository>().InstancePerRequest();
            containerBuilder.RegisterType<SubmitOptionsRepository>().As<ISubmitOptionsRepository>().InstancePerRequest();
            containerBuilder.RegisterType<TestDbEntities>().InstancePerRequest();

            return containerBuilder.Build();
        }
    }
}