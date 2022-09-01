using RG.Application.Contracts.AlgoHR.Business.Vw_OutSideTask.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.AlgoHR.Business
{
    public class Vw_OutSideTaskService : IVw_OutSideTaskService
    {
        
        private readonly IVw_OutSideTaskRepository vw_OutSideTaskRepository;

        public Vw_OutSideTaskService(IVw_OutSideTaskRepository _vw_OutSideTaskRepository)
        {
            
            vw_OutSideTaskRepository = _vw_OutSideTaskRepository;
        }
        public IQueryable<Vw_OutSideTask> GetEmpOutsideTaskApplications(OutSideTaskSearchQM searchModel, CancellationToken cancellationToken)
        {
            return vw_OutSideTaskRepository.GetEmpOutsideTaskApplications(searchModel, cancellationToken);
        }
    }
}
