using SLTInvoicingBackend.Core.ApplicationServices;
using SLTInvoicingBackend.Core.ApplicationServices.Services;
using SLTInvoicingBackend.Core.DomainServices;
using SLTInvoicingBackend.Infrastructure.Repositories;
using SLTInvoicingBackend.WebAPI.Resolver;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using System.Web.Http.Cors;
using AutoMapper;
using SLTInvoicingBackend.WebAPI.DTOs;
using SLTInvoicingBackend.Core;
using SLTInvoicingBackend.Infrastructure;
using System.Web;

namespace SLTInvoicingBackend.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");//origins,headers,methods   
            config.EnableCors(cors);

            //Map Objects with Automapper
            var confi = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<LoginDTO, CASHIER>();
                cfg.CreateMap<CASHIER, UserDTO>();
                cfg.CreateMap<EQUIPMENT, EquipmentDTO>();
                cfg.CreateMap<PRICEREVISION, PricerevisionDTO>();
                cfg.CreateMap<STOCK, StockDTO>();
                cfg.CreateMap<InvoicehdDTO, INVOICEHEADER>();
                cfg.CreateMap<InvoicedtDTO, INVOICEDETAIL>();
                cfg.CreateMap<INVOICEHEADER, InvoicehdDTO>();
                cfg.CreateMap<INVOICEDETAIL, InvoicedtDTO>();
                cfg.CreateMap<RETURNGOOD, ReturngdDTO>();
                cfg.CreateMap<ReturngdDTO, RETURNGOOD>();
                cfg.CreateMap<TAX, TaxDTO>();
                cfg.CreateMap<ERP_INV_TRAN_TYPE, TransactionTypeDTO>();
                cfg.CreateMap<ERP_PURPOSEOFUSE, PurposeofUseDTO>();
                cfg.CreateMap<DefectGoodDTO, DEFECTGOOD>();
                cfg.CreateMap<DEFECTGOOD, DefectGoodDTO>();
                cfg.CreateMap<BILLINGCENTER, BillingcenterDTO>();
                cfg.CreateMap<QuotationhdDTO, QUOTATIONHEADER>();
                cfg.CreateMap<QuotationdtDTO, QUOTATIONDETAIL>();
                cfg.CreateMap<QUOTATIONHEADER, QuotationhdDTO>();
                cfg.CreateMap<QUOTATIONDETAIL, QuotationdtDTO>();
                //cfg.AddMaps(typeof(UserDTO));
            }
            );
           
            IMapper mapper = confi.CreateMapper();

            // Web API configuration and services
            var container = new UnityContainer();
            if (HttpContext.Current != null)
            {
                container.RegisterType<IDatabaseContext, InvoicingContext>(new HierarchicalLifetimeManager());
            }
            else
            {
                container.RegisterType<IDatabaseContext, InvoicingContext>(new ContainerControlledLifetimeManager());
            }
            container.RegisterType<ICashierService, CashierService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICashierRepository, CashierRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogRepository, LogRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentService, EquipmentService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentRepository, EquipmentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IInvoiceService, InvoiceService>(new HierarchicalLifetimeManager());
            container.RegisterType<IInvoiceRepository, InvoiceRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IReturngoodRepository, ReturngoodRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IReturngoodService, ReturngoodService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaxRepository, TaxRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaxService, TaxService>(new HierarchicalLifetimeManager());
            container.RegisterType<IStockMgtRepository, StockMgtRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IStockRepository, StockRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IStockService, StockService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBillingcenterRepository, BillingcenterRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBillingcenterService, BillingcenterService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionTypeService, TransactionTypeService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITransactionTypeRepository, TransactionTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPurposeofuseRepository, PurposeofuseRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPurposeofuseService, PurposeofuseService>(new HierarchicalLifetimeManager());

            container.RegisterType<IDefectgoodRepository, DefectgoodRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDefectgoodService, DefectgoodService>(new HierarchicalLifetimeManager());
            container.RegisterType<IGRNDataRepository, GRNDataRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGRNDataService, GRNDataService>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuotationRepository, QuotationRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuotationService, QuotationService>(new HierarchicalLifetimeManager());
            container.RegisterInstance(mapper);
           
            config.DependencyResolver = new UnityResolver(container);

            // Add Custom validation filters  
            //config.Filters.Add(new ValidateModelStateFilter());
            //config.Filters.Add(new CustomExceptionFilter());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

         

          
        }
    }
}
