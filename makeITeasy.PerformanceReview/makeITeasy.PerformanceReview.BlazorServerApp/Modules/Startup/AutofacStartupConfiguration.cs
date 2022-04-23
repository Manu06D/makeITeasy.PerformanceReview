using Autofac.Extensions.DependencyInjection;
using Autofac;
using FluentValidation;
using makeITeasy.AppFramework.Core.Helpers;
using makeITeasy.AppFramework.Core.Infrastructure.Autofac;
using makeITeasy.AppFramework.Core.Interfaces;
using makeITeasy.AppFramework.Models;
using makeITeasy.PerformanceReview.BusinessCore.Services;
using makeITeasy.PerformanceReview.Infrastructure.Data;
using makeITeasy.PerformanceReview.Infrastructure;
using System.Reflection;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace makeITeasy.PerformanceReview.BlazorServerApp.Modules.Startup
{
    public static class AutofacStartupConfiguration
    {
        public static void ConfigureAutofac(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            Assembly modelAssembly = typeof(UserService).Assembly;
            Assembly[] assembliesToScan = new Assembly[]
                {
                    makeITeasy.AppFramework.Core.AppFrameworkCore.Assembly,
                    modelAssembly,
                    AppFrameworkModels.Assembly
                };

            builder.Host.ConfigureContainer<ContainerBuilder>(
            builder =>
            {
                builder.RegisterModule(new RegisterAutofacModule() { Assemblies = assembliesToScan });
                builder.RegisterAutoMapper(assembliesToScan);
                builder.RegisterMediatR(assembliesToScan);

                builder.RegisterType<PeformanceReviewDbContext>();

                builder.RegisterGeneric(typeof(PeformanceReviewCatalogRepository<>)).As(typeof(IAsyncRepository<>)).InstancePerLifetimeScope()
                        .PropertiesAutowired()
                        .OnActivated(args => AutofacHelper.InjectProperties(args.Context, args.Instance, true));

                builder.RegisterAssemblyTypes(modelAssembly).Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();

                builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            }
        );
        }
    }
}
