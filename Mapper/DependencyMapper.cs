using AutoMapper;
using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Entities.Fiancial;
using Domain.Entities.Financial;
using Domain.Entities.Product;
using Domain.Entities.Stock;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Repository.Product;
using Domain.Interface.Repository.Stock;
using Domain.Interface.Service;
using Domain.Interface.Service.Financial;
using Domain.Interface.Service.Product;
using Domain.Interface.Service.Stock;
using Domain.Model.Auth;
using Domain.Model.Common;
using Domain.Model.Contact;
using Domain.Model.Financial;
using Domain.Model.Product;
using Domain.Model.Stock;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repository;
using Repository.Auth;
using Repository.Common;
using Repository.Financial;
using Repository.Product;
using Repository.Stock;
using Service;
using Service.Auth;
using Service.Financial;
using Service.Product;
using Service.Stock;

namespace Mapper
{
    public class DependencyMapper
    {
        public static void MapDependenceInjection(IServiceCollection services, IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            #region Repository
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IInventoryAdjustmentRepository, InventoryAdjustmentRepository>();
            services.AddScoped<IStockLocationRepository, StockLocationRepository>();
            services.AddScoped<IStockReleaseRepository, StockReleaseRepository>();
            services.AddScoped<IStockBalanceRepository, StockBalanceRepository>();

            services.AddScoped<IFinancialReleaseRepository, FinancialReleaseRepository>();
            services.AddScoped<IFinancialReleaseTypeRepository, FinancialReleaseTypeRepository>();
            services.AddScoped<IFinancialBalanceRepository, FinancialBalanceRepository>();
            services.AddScoped<IManualTransactionRepository, ManualTransactionRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();


            services.AddScoped<IAuthRepository>(provider =>
            {
                var autenticacaoUrl = configuration["AuthenticationServiceUrl"];

                return new AuthRepository(autenticacaoUrl, configuration, jwtSettings);
            });



            #endregion

            #region Service
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IUserProfileService, UserProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUnitOfWork, UnityOfWork>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IInventoryAdjustmentService, InventoryAdjustmentService>();
            services.AddTransient<IStockReleaseService, StockReleaseService>();

            services.AddTransient<IFinancialReleaseService, FinancialReleaseService>();
            services.AddTransient<IFinancialReleaseTypeService, FinancialReleaseTypeService>();
            services.AddTransient<IManualTransactionService, ManualTransactionService>();
            

            #endregion
        }


        #region Entity
        public static IMapper Configure()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserProfile, UserProfileResponse>();
                cfg.CreateMap<UserProfileResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<UserProfileRequest, UserProfile>();

                cfg.CreateMap<User, UserResponse>()
                .ForMember(x => x.ProfileUuid, opt => opt.MapFrom(o => o.Profile.Uuid));
                cfg.CreateMap<UserRequest, User>();
                
                cfg.CreateMap<ContactEntity, ContactResponse>();
                cfg.CreateMap<ContactRequest, ContactEntity>();

                cfg.CreateMap<FinancialReleaseEntity, FinancialReleaseResponse>();
                cfg.CreateMap<FinancialReleaseRequest, FinancialReleaseEntity>();

                cfg.CreateMap<FinancialReleaseTypeEntity, FinancialReleaseTypeResponse>();
                cfg.CreateMap<FinancialReleaseTypeRequest, FinancialReleaseTypeEntity>();

                cfg.CreateMap<ManualTransactionEntity, ManualTransactionResponse>();
                cfg.CreateMap<ManualTransactionRequest, ManualTransactionEntity>();

                
                cfg.CreateMap<FinancialReleaseTypeResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));

                cfg.CreateMap<ProductCategory, ProductCategoryResponse>();
                cfg.CreateMap<ProductCategoryResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<ProductCategoryRequest, ProductCategory>();

                cfg.CreateMap<ProductEntity, ProductResponse>()
                .ForMember(x => x.ProductCategoryUuid, opt => opt.MapFrom(o => o.ProductCategory.Uuid));
                cfg.CreateMap<ProductResponse, OptionItemResponse>()
                .ForMember(x => x.Label, opt => opt.MapFrom(o => o.Name))
                .ForMember(x => x.Value, opt => opt.MapFrom(o => o.Uuid));
                cfg.CreateMap<ProductRequest, ProductEntity>();

                cfg.CreateMap<StockLocationEntity, StockLocationResponse>();

                cfg.CreateMap<StockReleaseEntity, StockReleaseResponse>();
                cfg.CreateMap<StockReleaseEntity, StockReleaseResponse>();

                cfg.CreateMap<InventoryAdjustmentEntity, InventoryAdjustmentResponse>();
                cfg.CreateMap<InventoryAdjustmentRequest, InventoryAdjustmentEntity>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
        #endregion

    }
}
