using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.DBEntities.AOP.Business;
using RG.Infrastructure.Persistence.AOPDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AOP.Business
{
    public class Tbl_Issuance_DetailsRepository : GenericRepository<Tbl_Issuance_Details>, ITbl_Issuance_DetailsRepository
    {
        private readonly AOPDBContext dbCon;
        public Tbl_Issuance_DetailsRepository(AOPDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

    }
}
