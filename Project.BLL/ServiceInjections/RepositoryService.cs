using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjections
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepServices(this IServiceCollection services)
        {
            /*
             
             Transient Services: Bir Request'in ulastıgı Scope'un parametre kümesinde aynı tipten kac tane varsa o kadar instance alınır...Manager ve Repository'ler icin anlamsızdır...Cünkü bunlardan bir tanesi bir Request'teki scope icin yeterlidir...



             Scoped Services: Bir Request'te Scope'un parammtre kümesinde aynı tipte birden fazla parametre olsa bile 1 instance üzerinden calısırsınız...Ancak bu Singleton degildir...Cünkü Request'in işi bittigi zaman garbage collector Ram'den o instance'i kaldırır...Bir Request'in scope'unda aynı tipte birden fazla instance repository'ler ve Manager'lar icin gerekli degildir...O yüzden Scoped tercih edilir...




             Singleton Services: Bir REquest'in ulastıgı Scope'un parametre kümesinde bir tip görüldügü anda instance alınır ve program kapatılıncaya kadar o instance'dan devam edilir...Manager ve Repository'ler icin cok tehlikelidir...

            
             
             
             
             
             */
            // Bu yaptığımız sisteme IOC sistem denir.
           
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();    
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }
    }
}
