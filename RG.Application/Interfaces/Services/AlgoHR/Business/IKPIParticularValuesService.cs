using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.KPIParticularValuess.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface IKPIParticularValuesService
    {
        Task<RResult> KPIParticularValuesCreate(List<CompanyKPICreateDTM> kpiData, CancellationToken cancellationToken);
    }
}
