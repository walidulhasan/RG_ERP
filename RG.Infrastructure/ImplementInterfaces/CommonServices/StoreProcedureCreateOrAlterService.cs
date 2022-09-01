using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RG.Application.Common.CommonInterfaces;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.CommonServices
{
    public class StoreProcedureCreateOrAlterService : IStoreProcedureCreateOrAlterService
    {
        private readonly IServiceProvider _serviceProvider;

        public StoreProcedureCreateOrAlterService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public  void CreateOrAlterSQL()
        {
            using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<MaxcoDBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
