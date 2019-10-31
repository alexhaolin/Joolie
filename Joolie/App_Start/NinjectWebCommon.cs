[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Joolie.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Joolie.App_Start.NinjectWebCommon), "Stop")]

namespace Joolie.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using DomainRepository.Abstract;
    using DomainRepository.Concrete;
    using DomainRepository.Entities;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Moq;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

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
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //    new Product{
            //        ProductID=1,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //     new Product{
            //        ProductID=2,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //      new Product{
            //        ProductID=3,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //       new Product{
            //        ProductID=4,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //        new Product{
            //        ProductID=5,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //         new Product{
            //        ProductID=6,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //          new Product{
            //        ProductID=7,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //           new Product{
            //        ProductID=8,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //            new Product{
            //        ProductID=9,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" },
            //         new Product{
            //        ProductID=10,ManufacturerID=1,SubCategoryID=1,ProductName="Hair",ProductImage="No image",Model="fab",
            //        Series="232",Model_Year=2000,Series_info="adfa" }

            //});
            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

        }
    }
}
