using Microsoft.AspNetCore.Hosting;
using SolrNet;

namespace Real_Estate_Management_System_düzenleme.Controllers
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddAutoMapper(typeof(IStartup));
        services.AddControllers();
    }

}
