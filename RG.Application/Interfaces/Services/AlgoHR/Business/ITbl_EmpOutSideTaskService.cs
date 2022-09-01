using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.Tbl_EmpOutSideTask.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
  public interface ITbl_EmpOutSideTaskService
    {
        Task<RResult> SaveTbl_EmpOutSideTask(OutsideDutyApplicationDTM model, bool saveChange = true);
    }
}
