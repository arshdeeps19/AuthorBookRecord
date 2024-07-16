using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Service_Layer.Interfaces;
using Service_Layer.Services;
using Domain_Layer.Interfaces;
using AutoMapper;
using AuthorBookRecord.Mapper;
using Unity.AspNet.Mvc;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;

namespace AuthorBookRecord
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private void RegisterTypes(IUnityContainer container)
        {
            // Register services
            container.RegisterType<IBookService, BookService>();
            container.RegisterType<IAuthorService, AuthorService>();

            // Register repositories
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();

            // Register AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            IMapper mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            // Debug: Print all registered types
            var registrations = container.Registrations;
            foreach (var registration in registrations)
            {
                System.Diagnostics.Debug.WriteLine($"Registered: {registration.RegisteredType} => {registration.MappedToType}");
            }
        }
    }
}
