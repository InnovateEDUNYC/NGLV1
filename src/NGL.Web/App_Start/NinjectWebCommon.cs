using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NGL.Web;
using NGL.Web.App_Start;
using NGL.Web.Data;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;
using NGL.Web.Data.Repositories;
using NGL.Web.Infrastructure;
using NGL.Web.Infrastructure.Azure;
using NGL.Web.Models;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace NGL.Web
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<System.Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<INglDbContext>().To<NglDbContext>().InSingletonScope().WithConstructorArgument(ConfigManager.EdmxConnectionString);
            kernel.Bind<IUnitOfWork>().To<NglDbContext>().InRequestScope();
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind<IFileUploader>().To<AzureStorageUploader>().InSingletonScope();
            kernel.Bind<IFileDownloader>().To<AzureStorageDownloader>().InSingletonScope();

            kernel
                .Bind<UserManager<ApplicationUser>>()
                .ToMethod<UserManager<ApplicationUser>>(c =>
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(c.Kernel.Get<ApplicationDbContext>())));

            kernel.Bind(x => x
                .FromThisAssembly()
                .SelectAllTypes()
                .InheritedFrom<IRepositoryBase>()
                .BindAllInterfaces());

            kernel.Bind(
            x => x.FromThisAssembly()
                .SelectAllTypes()
                .InheritedFrom<IValidator>()
                .BindDefaultInterfaces());

            kernel.Bind(
                x => x.FromThisAssembly()
                    .SelectAllTypes()
                    .InheritedFrom(typeof (IMapper<,>))
                    .BindDefaultInterfaces());
        }        
    }
}
