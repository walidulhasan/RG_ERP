using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class OrderClassificationRepository : GenericRepository<OrderClassification>, IOrderClassificationRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderClassificationRepository(MaxcoDBContext maxcoDBContext) : base(maxcoDBContext)
        {
            _dbCon = maxcoDBContext;
        }
        public async Task<List<SelectListItem>> DDLOrderClassification(CancellationToken cancellationToken)
        {
            var data = await _dbCon.OrderClassification.Where(x => x.IsActive == true && x.IsRemoved == false)
                .Select(r => new SelectListItem
                {
                    Text = r.ClassificationName,
                    Value = r.OrderClassificationID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
