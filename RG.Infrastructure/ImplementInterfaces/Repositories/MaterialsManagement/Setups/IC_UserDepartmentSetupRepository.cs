using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.MaterialsManagement.Setups.IC_UserDepartmentSetups.Commands.DataTransferModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.DBEntities.MaterialsManagement.Setup;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Setups
{
    public class IC_UserDepartmentSetupRepository : GenericRepository<IC_UserDepartmentSetup>, IIC_UserDepartmentSetupRepository
    {
        private readonly MaterialsManagementDBContext dbCon;

        public IC_UserDepartmentSetupRepository(MaterialsManagementDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<RResult> SaveUserWiseDepartmentAssaign(List<IC_UserDepartmentSetup> list, CancellationToken cancellationToken)
        {
            var rresult = new RResult();
            await dbCon.IC_UserDepartmentSetup.AddRangeAsync(list);
            await dbCon.SaveChangesAsync(cancellationToken);
            rresult.result = 1;
            rresult.message = ReturnMessage.InsertMessage;
            return rresult;

        }

        public async Task<RResult> UserDepartmentRemove(List<IC_UserDepartmentSetupDTM> list, CancellationToken cancellationToken)
        {
            //var rresult = new RResult();
            //var obj = await dbCon.IC_UserDepartmentSetup.Where(b => b.Id == ID).FirstAsync();
            //obj.IsRemoved = true;
            //obj.ModifyDate = DateTime.Now;
            //dbCon.IC_UserDepartmentSetup.Update(obj);
            //await dbCon.SaveChangesAsync(cancellationToken);
            //rresult.result = 1;
            //rresult.message = ReturnMessage.DeleteMessage;
            //return rresult;

            var rResult = new RResult();

            var deptSetupID = list.Select(b => b.Id).ToList();

            var dbData = await dbCon.IC_UserDepartmentSetup
                .Where(b => b.IsRemoved == false  && deptSetupID.Contains(b.Id)).ToListAsync();
            dbData.ForEach(b => { b.IsRemoved = true;  });
            await dbCon.SaveChangesAsync(cancellationToken);
            rResult.result = 1;
            rResult.message = ReturnMessage.DeleteMessage;

            return rResult;

        }
        //public async Task<List<UserWiseDepartmentResponseModel>> GetUserWiseDepartmentByUserID(int userID, CancellationToken cancellationToken)
        //{



        //    var rtnList = await (from d in dbCon.IC_Department
        //                         join asd in dbCon.IC_UserDepartmentSetup on d.ID equals asd.DepartmentId into tblUserDepartment
        //                         from asd in tblUserDepartment.DefaultIfEmpty()
        //                        // where asd.UserId == userID
        //                         select new UserWiseDepartmentResponseModel() {
        //                         DepartmentId=asd.DepartmentId,
        //                         UserID=asd.UserId.Value,
        //                         DepartmentName=d.Name,
        //                         IsRemove=asd.IsRemoved
        //                         }).ToListAsync(cancellationToken);



        //    return rtnList;
        //}
    }
}
