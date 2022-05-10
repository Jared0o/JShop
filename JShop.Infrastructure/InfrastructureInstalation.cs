using JShop.Core.Entities.Identity;
using JShop.Core.Repositories;
using JShop.Infrastructure.Data;
using JShop.Infrastructure.Repositories;
using JShop.Infrastructure.Services;
using JShop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace JShop.Infrastructure
{
    public static class InfrastructureInstalation
    {
        public static IServiceCollection InfrastructureServiceInstalation(this IServiceCollection service, IConfiguration config)
        {
            //repositories
            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped<ITaxRepository, TaxRepository>();
            service.AddScoped<IBrandRepository, BrandRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IProductReposiotry, ProductRepository>();

            //services
            service.AddScoped<ITaxService, TaxService>();
            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IBrandService, BrandService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IProductService, ProductService>();

            //Automapper
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            //identity config
            service.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<JShopContext>();

            //efcore config
            service.AddDbContext<JShopContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SqlServerConnectionString"));
            });

            //jwt config
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            //authorization config
            service.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminRoleRequire", policy => policy.RequireRole(BaseRoleEnum.Admin.ToString()));
                opt.AddPolicy("OperatorRoleRequire", policy => policy.RequireRole(BaseRoleEnum.Admin.ToString(), BaseRoleEnum.Operator.ToString()));
                opt.AddPolicy("UserRoleRequire", policy => policy.RequireRole(BaseRoleEnum.Admin.ToString(), BaseRoleEnum.User.ToString(), BaseRoleEnum.Operator.ToString()));
            });

            return service;
        }
    }
}
