using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Setups
{
    public interface IIC_ProcessSetupService
    {
        Task<List<SelectListItem>> GetDDLIC_ProcessSetup();
    }
}
