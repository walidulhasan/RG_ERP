using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Embro.Setups.BalanceSheetGroupMaps.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class BalanceSheetGroupMapRepository : GenericRepository<BalanceSheetGroupMap>, IBalanceSheetGroupMapRepository
    {
        private readonly EmbroDBContext dbCon;
        public BalanceSheetGroupMapRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<ParticularGroupsRM>> GetParticularGroups(int particularSerial, int groupCategoryID, CancellationToken cancellationToken)
        {
            var data = await (from m in dbCon.BalanceSheetGroupMap
                              join g in dbCon.COAGroup on m.COAGroupID equals g.GroupID
                              where m.ParticularSerial == particularSerial && m.GroupCategoryID == groupCategoryID
                              orderby g.GroupSerial
                              select new ParticularGroupsRM
                              {
                                  ParticularSerial = m.ParticularSerial,
                                  COAGroupID = m.COAGroupID,
                                  GroupCode = g.GroupCode,
                                  COAGroupName = g.GroupName
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
