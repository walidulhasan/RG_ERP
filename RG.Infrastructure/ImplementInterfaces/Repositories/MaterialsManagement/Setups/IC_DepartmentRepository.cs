using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_DepartmentRepository : GenericRepository<IC_Department>, IIC_DepartmentRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_DepartmentRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }
        public async Task<List<SelectListItem>> DDLGetDepartmentByUserID(int userID, CancellationToken cancellationToken)
        {
            var rtnList = await (from d in dbCon.IC_Department
                                 join du in dbCon.IC_UserDepartmentSetup on d.ID equals du.DepartmentId
                                 where du.UserId == userID
                                 select new SelectListItem()
                                 {
                                     Text = d.Name,
                                     Value = d.ID.ToString()
                                 }).OrderBy(b => b.Text).ToListAsync(cancellationToken);
            return rtnList;
        }
        public async Task<List<SelectListItem>> DDLGetDepartmentList(CancellationToken cancellationToken, int ID = 0)
        {
            var rtnList = await (from d in dbCon.IC_Department

                                 where ID == 0 || d.ID == ID
                                 select new SelectListItem()
                                 {
                                     Text = d.Name,
                                     Value = d.ID.ToString()
                                 }).OrderBy(b => b.Text).ToListAsync(cancellationToken);
            return rtnList;
        }
        public async Task<List<IC_Department>> GetAllData()
        {
            // var list =await dbCon.IC_Department.ToListAsync();
            var list = await GetAllAsync();
            return list.ToList();
        }
    }
}
