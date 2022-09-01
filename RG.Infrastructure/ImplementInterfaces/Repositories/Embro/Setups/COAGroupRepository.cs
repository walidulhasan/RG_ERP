using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.COAGroups.Querirs.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.COAGroupings;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class COAGroupRepository : GenericRepository<COAGroup>, ICOAGroupRepository
    {
        private readonly EmbroDBContext _dbCon;

        public COAGroupRepository(EmbroDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<bool> IsDuplicateValue(COAGroupingCreateVM model)
        {
            var data = await _dbCon.COAGroup             
             .Where(x=>x.GroupCategoryID==model.GroupCategoryID && x.GroupID!= model.GroupID && (x.GroupName == model.GroupName || x.GroupCode == model.GroupCode || x.GroupSerial == model.GroupSerial)).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SelectListItem>> DDLCOAGroup(int categoryID, string predict, CancellationToken cancellationToken)
        {
            var query = _dbCon.COAGroup.Where(x => x.IsActive == true && x.IsRemoved == false);
            if (categoryID > 0)
                query = query.Where(x => x.GroupCategoryID == categoryID);

            if (predict != null)
                query = query.Where(x => x.GroupCode.Contains(predict) || x.GroupName.Contains(predict));
               var data=await query.Select(r => new SelectListItem
                {
                    Text = $"{r.GroupCode}. {r.GroupName}",
                    Value = r.GroupID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }

        public IQueryable<COAGroupingRM> GetListOfCOAGroup()
        {
            var queryList = from cg in _dbCon.COAGroup
                            join cgc in _dbCon.COAGroupCategorie on cg.GroupCategoryID equals cgc.GroupCategoryID
                            where cg.IsActive == true && cg.IsRemoved == false
                            select new COAGroupingRM()
                            {
                                GroupID = cg.GroupID,
                                GroupCategoryID = cg.GroupCategoryID,
                                GroupCode = cg.GroupCode,
                                GroupName = cg.GroupName,
                                GroupSerial = cg.GroupSerial,
                                GroupCategoryName = cgc.GroupCategoryName
                            };
            //var que = queryList.ToQueryString();
            return queryList;
        }
    }
}
