using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class User_SetupRepository : GenericRepository<User_Setup>, IUser_SetupRepository
    {
        private readonly MaxcoDBContext dbCon;

        public User_SetupRepository(MaxcoDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<User_Setup> GetUserSetupDetails(int UserID, CancellationToken cancellationToken)
        {
            var obj = await dbCon.User_Setup.Where(b => b.ID == UserID)
               .Select(b => new User_Setup()
               {
                   ID = b.ID,
                   CompanyID = b.CompanyID,
                   BusinessID = b.BusinessID,
                   UserName = b.UserName,
                   Password = b.Password,
                   DomainID = b.DomainID,
                   Status = b.Status
               }).FirstAsync();
            return obj;

        }

        public async Task<List<SelectListItem>> GetDDLAlgoUser(int CompanyID = 0, string Predict = "", CancellationToken cancellationToken = default)
        {
            var objQuery = from u in dbCon.User_Setup
                           where u.Status > 0
                           select new
                           {
                               CompanyID = u.CompanyID,
                               UserName = u.UserName,
                               ID = u.ID
                           };
            if (CompanyID > 0)
            {
                objQuery = objQuery.Where(b => b.CompanyID == CompanyID);
            }
            if (!string.IsNullOrWhiteSpace(Predict))
            {
                objQuery = objQuery.Where(b => b.UserName.Contains(Predict));
            }
            var data = await objQuery.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.UserName
            }).ToListAsync(cancellationToken);

            return data;

        }
    }
}
