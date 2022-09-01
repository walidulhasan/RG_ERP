using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class OrderSchedulingRepository : GenericRepository<OrderScheduling>, IOrderSchedulingRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderSchedulingRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
