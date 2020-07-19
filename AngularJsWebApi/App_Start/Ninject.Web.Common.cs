[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AngularJsWebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AngularJsWebApi.App_Start.NinjectWebCommon), "Stop")]

namespace AngularJsWebApi.App_Start
{
    using System;
    using System.Web;
    using OnlineShop.IBLL;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using OnlineShop.BusinessLayer;
    using System.Web.Http;
    using Ninject.WebApi.DependencyResolver;
    using OnlineShop.DataAccessLayer.Repository;
    using OnlineShop.DataAccessLayer;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
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
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
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
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
            kernel.Bind<IProduct>().To<ProductManager>().InRequestScope();
            kernel.Bind<IProductDA>().To<ProductDA>().InRequestScope();
            kernel.Bind<ICategory>().To<CategoryManager>().InRequestScope();
            kernel.Bind<ICategoryDA>().To<CategoryDA>().InRequestScope();
        }        
    }
}