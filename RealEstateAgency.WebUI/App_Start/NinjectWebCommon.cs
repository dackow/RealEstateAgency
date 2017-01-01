[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RealEstateAgency.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RealEstateAgency.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace RealEstateAgency.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Moq;
    using Domain.Abstract;
    using Domain.Entities;
    using System.Collections.Generic;
    using Domain.Concrete;

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
            kernel.Bind<IOfferRepository>().To<DBOffersRepository>();
            //Mock<IOfferRepository> mock = new Mock<IOfferRepository>();
            //mock.Setup(m => m.Offers).Returns(new List<Offer>
            //{
            //    new Offer { Name = "Mieszkanie 120m2 w centrum", Description = "Super mieszkanie w centrum Rzeszowa, normalnie rewelka", Price = 200000, Category = "M"},
            //    new Offer { Name = "Mieszkanie 50m2", Description = "Fajne mieszkanie w centrum Rzeszowa,", Price = 220000, Category = "M"},
            //    new Offer { Name = "Działka w Solinie", Description = "Koło Bóbrki, dobra lokalizacja", Price = 84000, Category = "Z"}
            //});

            //kernel.Bind<IOfferRepository>().ToConstant(mock.Object);
        }        
    }
}
