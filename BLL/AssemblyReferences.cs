
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
            
            return services;
        }
    }
}
