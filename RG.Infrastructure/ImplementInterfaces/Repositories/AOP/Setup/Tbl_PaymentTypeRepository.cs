using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.AOP.Setup;
using RG.DBEntities.AOP.Setup;
using RG.Infrastructure.Persistence.AOPDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AOP.Setup
{
    public class Tbl_PaymentTypeRepository : GenericRepository<Tbl_PaymentType>, ITbl_PaymentTypeRepository
    {
        private readonly AOPDBContext dbCon;
        public Tbl_PaymentTypeRepository(AOPDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLPaymentType()
        {
            var data = await dbCon.Tbl_PaymentType.Where(x => x.IsActive == true)
                .Select(r => new SelectListItem
                {
                    Text = r.PaymentType,
                    Value = r.PaymentID.ToString()
                }).ToListAsync();
            return data;
        }
    }
}
