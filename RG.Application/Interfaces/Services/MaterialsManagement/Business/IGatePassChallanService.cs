using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.MaterialsManagement.Business
{
    public interface IGatePassChallanService
    {
        Task<GatePassChallanMasterVM> GetGatePassChallanRecord(int gatePassID, CancellationToken cancellationToken);
    }
}
