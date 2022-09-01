using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class Tbl_CompanyRepository : GenericRepository<Tbl_Company>, ITbl_CompanyRepository
    {
        private readonly AlgoHRDBContext dbCon;
        public Tbl_CompanyRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<IdNamePairRM>> GetDDLEmbroCompanyLookUp(int? CompanyID = 0, CancellationToken cancellationToken = default)
        {
            var comp=   dbCon.Tbl_Company.Where(b=>b.Cmp_Name.Length>0);
            if(CompanyID.HasValue==true && CompanyID.Value > 0)
            {
                comp = comp.Where(b => b.EmbroCompanyID == CompanyID);
            }

            return await comp.Select(s => new IdNamePairRM()
            {
                ID = s.EmbroCompanyID,
                Name = s.Cmp_Name,
                ShortName = s.Cmp_ShortName
            }).Distinct().ToListAsync(cancellationToken);
        }
    }
}
