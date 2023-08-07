using BBG.Monolit.DataAccess.Repositories;
using BBG.Monolit.DataAccess.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace BBG.Monolit.Extensions
{
    public static class ServiceExterntions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddCustomRepository<TEntity, IRepository>(this IServiceCollection services)
            where TEntity : class
            where IRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, IRepository>();
            
            return services;
        }
    }
}
