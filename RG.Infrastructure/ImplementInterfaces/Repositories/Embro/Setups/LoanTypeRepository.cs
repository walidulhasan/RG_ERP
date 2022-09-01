using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Embro.Setups.LoanTypes.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.ViewModel.Embro.Setup.LoanType;
using RG.DBEntities.Embro.Setup;
using RG.Infrastructure.Persistence.EmbroDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Setups
{
    public class LoanTypeRepository:GenericRepository<LoanType>,ILoanTypeRepository
    {
        private readonly EmbroDBContext _dbCon;

        public LoanTypeRepository(EmbroDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

        public IQueryable<LoanTypeRM> GetAllGridData()
        {
            var query = _dbCon.LoanType
               .Where(x => x.IsActive == true && x.IsRemoved == false )
               .Select(r => new LoanTypeRM
               {
                   ID=r.ID,
                   LoanTypeName = r.LoanTypeName,
                   LoanTypeShortName = r.LoanTypeShortName
               });
            return query;
        }

        public async Task<int> MaxTableId()
        {
            var maxValue = await _dbCon.LoanType
                .OrderByDescending(b => b.ID)
                .FirstOrDefaultAsync();
            if (maxValue == null)
            {
                return 1;
            }
            return maxValue.ID + 1;
        }

     
        public async Task<bool> IsDuplicateValue(LoanTypeCreateVM model)
        {
            var data = await _dbCon.LoanType
            .Where(x => x.LoanTypeName == model.LoanTypeName && x.IsActive==true && x.IsRemoved==false).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<SelectListItem>> DDLLoanTypeName(CancellationToken cancellationToken)
        {
            var data = await (from b in _dbCon.LoanType
                              where b.IsActive==true && b.IsRemoved==false
                              select new SelectListItem
                              {
                                  Text = b.LoanTypeName,
                                  Value = b.ID.ToString()
                              }).ToListAsync(cancellationToken);
            return data;
        }
    }
}
