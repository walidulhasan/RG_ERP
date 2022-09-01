using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AOP.Setup
{
    public interface ITbl_PaymentTypeService
    {
        Task<List<SelectListItem>> DDLPaymentType();
    }
}
