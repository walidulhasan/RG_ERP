using Microsoft.AspNetCore.Mvc.Rendering;
using RG.DBEntities.AOP.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AOP.Setup
{
    public interface ITbl_PaymentTypeRepository : IGenericRepository<Tbl_PaymentType>
    {
        Task<List<SelectListItem>> DDLPaymentType();
    }
}
