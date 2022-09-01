using RG.Application.Common.Models;
using RG.Application.ViewModel.AlgoHR.Business.EmployeeLeaveCancel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public  interface IEmployeeLeaveCancelService
    {
        Task<RResult> Create(EmployeeLeaveCancelVM model, bool saveChange = true);
    }
}
