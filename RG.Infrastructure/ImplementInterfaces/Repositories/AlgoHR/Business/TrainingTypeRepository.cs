using RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.Application.ViewModel.AlgoHR.Business.Training;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class TrainingTypeRepository:GenericRepository<TrainingType>, ITrainingTypeRepository
    {
        private AlgoHRDBContext dbCon;
        public TrainingTypeRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }
    }
}
