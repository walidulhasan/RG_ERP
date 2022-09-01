using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICBM_BankService
    {
        Task<List<SelectListItem>> DDLCBM_Bank(int CompanyID=0,string predict=null, CancellationToken cancellationToken=default);
    }
}
