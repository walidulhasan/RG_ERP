using RG.Application.Common.Models;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
   public class Tbl_EmpOutSideTaskRepository :GenericRepository<Tbl_EmpOutSideTask>, ITbl_EmpOutSideTaskRepository
    {
        private readonly AlgoHRDBContext _dbCon;
        public Tbl_EmpOutSideTaskRepository(AlgoHRDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<RResult> SaveTbl_EmpOutSideTask(Tbl_EmpOutSideTask entity, bool saveChange = true)
        {
            RResult rResult = new();
            await _dbCon.Tbl_EmpOutSideTask.AddAsync(entity);
            if (saveChange)
            {
                await _dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.statusCode = entity.OutSideTaskID;
                rResult.message = ReturnMessage.InsertMessage;
            }

            return rResult;
        }

        public async Task<RResult> UpdateTbl_EmpOutSideTask(Tbl_EmpOutSideTask entity, bool saveChange = true)
        {
            RResult rResult = new();
            _dbCon.Tbl_EmpOutSideTask.Update(entity);
            if(saveChange)
            await _dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
    }
}
