using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Commands.DataTransferModel;
using RG.Application.Contracts.FiniteScheduler.Setups.AssetLocations.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.FiniteScheduler.Setup;
using RG.DBEntities.FiniteScheduler.Setup;
using RG.Infrastructure.Persistence.FiniteSchedulerDB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.FiniteScheduler.Setup
{
    public class AssetLocationRepository : GenericRepository<AssetLocation>, IAssetLocationRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public AssetLocationRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<RResult> AssetLoactionAssing(AssetLocation model, bool saveChange)
        {
            RResult rResult = new();
            if (model != null)
            {

                if (model != null)
                {

                    await InsertAsync(model, saveChange);
                    rResult.result = 1;
                    rResult.message = ReturnMessage.UpdateMessage;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                }

            }
            return rResult;
        }

        public async Task<AssetLocationRM> GetAssetLoactionByID(int ID, CancellationToken cancellationToken)
        {
            try
            {
                var data = await (from al in dbCon.AssetLocation
                                  join ad in dbCon.AssetDepartment on al.DepartmentID equals ad.DepartmentID
                                  join adiv in dbCon.AssetDivision on ad.DivisionID equals adiv.DivisionID
                                  where al.IsActive == true && al.IsRemoved == false && al.ID == ID
                                  select new AssetLocationRM()
                                  {
                                      ID = al.ID,
                                      AssetID = al.AssetID,
                                      BuildingID = al.BuildingID,
                                      DateFrom = al.DateFrom,
                                      DateTo = al.DateTo,
                                      CompanyID=adiv.EmbroCompanyID,
                                      DivisionID=adiv.DivisionID,
                                      DepartmentID = al.DepartmentID,
                                      EmployeeCode = al.EmployeeCode,
                                      FloorID = al.FloorID,
                                      IsReturned = al.IsReturned
                                  }).FirstOrDefaultAsync(cancellationToken);
                return data;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
