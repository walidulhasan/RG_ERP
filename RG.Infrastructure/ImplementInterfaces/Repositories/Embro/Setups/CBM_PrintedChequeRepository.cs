using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class CBM_PrintedChequeRepository:GenericRepository<CBM_PrintedCheque>, ICBM_PrintedChequeRepository
    {
        private readonly EmbroDBContext _dbCon;

        public CBM_PrintedChequeRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
    }
}
