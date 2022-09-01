using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Repositories.AOP.Setup;
using RG.Application.Interfaces.Services.AOP.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AOP.Setup
{
    public class Tbl_PaymentTypeService : ITbl_PaymentTypeService
    {
        private readonly ITbl_PaymentTypeRepository tbl_PaymentTypeRepository;

        public Tbl_PaymentTypeService(ITbl_PaymentTypeRepository _tbl_PaymentTypeRepository)
        {
            tbl_PaymentTypeRepository = _tbl_PaymentTypeRepository;
        }

        public async Task<List<SelectListItem>> DDLPaymentType()
        {
            return await tbl_PaymentTypeRepository.DDLPaymentType();
        }

    }
}
