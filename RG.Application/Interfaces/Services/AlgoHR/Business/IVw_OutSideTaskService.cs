using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface IVw_OutSideTaskService
    {
        IQueryable<Vw_OutSideTask> GetEmpOutsideTaskApplications(OutSideTaskSearchQM searchModel, CancellationToken cancellationToken);
    }
}
