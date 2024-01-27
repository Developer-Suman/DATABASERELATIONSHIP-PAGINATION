
using BLL.Repository.Implementation;
using BLL.Repository.Interface;
using BLL.Services.Implementation;
using BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class AssemblyReferences
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductServices, ProductServices>();


            return services;
        }
    }
}
