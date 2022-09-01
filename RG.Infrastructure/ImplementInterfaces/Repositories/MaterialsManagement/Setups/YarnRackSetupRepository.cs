using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
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
    public class YarnRackSetupRepository : GenericRepository<YarnRackSetup>, IYarnRackSetupRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;
        private readonly IMapper _mapper;

        public YarnRackSetupRepository(MaterialsManagementDBContext dbCon, IMapper mapper) : base(dbCon)
        {
            _dbCon = dbCon;
            _mapper = mapper;
        }

        public async Task<List<SelectListItem>> DDLBuildingFloorWiseRack(int buildingFloorID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.YarnRackSetup.Where(x => x.BuildingFloorID == buildingFloorID && x.IsActive == true && x.IsRemoved == false)
                .Select(x => new SelectListItem
                {
                    Text = x.RackName,
                    Value = x.RackID.ToString()
                }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>> DDLLotNowithRackWiseLotno(int RackID,string predict, CancellationToken cancellationToken)
        {
            IQueryable<SelectListItem> dataQuery;
            if (RackID > 0)
            {
                dataQuery =
                         from yrs in _dbCon.YarnRackSetup
                         join ysrs in _dbCon.YarnSubRackSetup on yrs.RackID equals ysrs.RackID
                         join yra in _dbCon.YarnRackAllocation on ysrs.SubRackID equals yra.SubRackID
                         join yst in _dbCon.Yarn_StockTransactions on yra.YarnStockTransactionID equals yst.YarnStockTransactionID
                         where yst.Status == 6 && yrs.RackID == RackID
                         group yst by yst.LotNo into g_yst
                         where g_yst.Sum(b=>b.TransactionQty)>0
                         select new SelectListItem
                         {
                             Text = g_yst.Key.Trim(),
                             Value = g_yst.Key.Trim()
                         };
            }
            else
            {
                dataQuery = from st in _dbCon.Yarn_StockTransactions
                            where st.Status == 6
                            group st by st.LotNo into g_st
                            where g_st.Sum(b=>b.TransactionQty)>0
                            select new SelectListItem()
                            {
                                Text = g_st.Key.Trim(),
                                Value = g_st.Key.Trim()
                            }
                            ;
            }
            if (predict != null)
            {
                dataQuery = dataQuery.Where(x => x.Text.Contains(predict));
            }

            var data = await dataQuery.ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<YarnRackSetup>> GetFloorWiseRackInfo(int buildingFloorID, CancellationToken cancellationToken)
        {
            var data = await _dbCon.YarnRackSetup
                                    .Include(x => x.YarnSubRackSetup.Where(y => y.IsActive == true && y.IsRemoved == false))
                             .Where(x => x.IsActive == true && x.IsRemoved == false && x.BuildingFloorID == buildingFloorID).ToListAsync(cancellationToken);

            return data;
        }

        public async Task<RResult> Remove(int rackID, CancellationToken cancellationToken)
        {
            RResult result = new();
            var data = await _dbCon.YarnRackSetup
                                    .Include(x => x.YarnSubRackSetup.Where(y => y.IsActive == true && y.IsRemoved == false && y.RackID==rackID))
                            .Where(x => x.IsActive == true && x.IsRemoved == false && x.RackID == rackID).FirstOrDefaultAsync();
            data.IsRemoved = true;
            data.YarnSubRackSetup.Where(x => x.RackID == rackID).ToList().ForEach(c => { c.IsRemoved = true;});
            var obj = _dbCon.Update(data);
            if (obj != null)
            {
                await _dbCon.SaveChangesAsync();
                result.result = 1;
                result.message = ReturnMessage.DeleteMessage;
            }
            else
            {
                result.result = 0;
                result.message = ReturnMessage.ErrorMessage;
            }
            return result;

        }

        public async Task<RResult> UpdateRackAllDetail(YarnRackSetup entity, CancellationToken cancellationToken)
        {
            RResult rResult = new RResult();
            try
            {
                var dbEntity = await _dbCon.YarnRackSetup
                                   .Include(x => x.YarnSubRackSetup.Where(y => y.IsActive == true && y.IsRemoved == false && y.RackID==entity.RackID))
                            .Where(x => x.IsActive == true && x.IsRemoved == false && x.RackID == entity.RackID).FirstAsync(cancellationToken);

                if (dbEntity!=null)
                {
                    dbEntity.RackName = entity.RackName;
                    dbEntity.RackShortName = entity.RackShortName;
                    dbEntity.RackSerial = entity.RackSerial;
                    dbEntity.BuildingFloorID = entity.BuildingFloorID;
                    dbEntity.RackDescription = entity.RackDescription;
                    dbEntity.RackRow = entity.RackRow;
                    dbEntity.RackColumn = entity.RackColumn;
                }
                else
                {
                    rResult.result = 0;
                    rResult.message = ReturnMessage.ErrorMessage;
                }

                foreach (var updatedSubRack in entity.YarnSubRackSetup)
                {
                    var existingChild = dbEntity.YarnSubRackSetup.Where(c => c.SubRackID == updatedSubRack.SubRackID).FirstOrDefault();
                    // Update child
                    if (existingChild != null)
                    {
                        existingChild.SubRackName = updatedSubRack.SubRackName;
                        existingChild.SubRackShortName = updatedSubRack.SubRackShortName;
                        existingChild.SubRackSerial = updatedSubRack.SubRackSerial;
                        existingChild.SubRackRowSerial = updatedSubRack.SubRackRowSerial;
                        existingChild.SubRackColumnSerial = updatedSubRack.SubRackColumnSerial;
                        existingChild.SubRackDescription = updatedSubRack.SubRackDescription;
                        existingChild.StorageLimit = updatedSubRack.StorageLimit;
                        _dbCon.Update(existingChild);
                    }
                    else
                    {
                        updatedSubRack.RackID = entity.RackID;
                        updatedSubRack.IsActive = true;
                        _dbCon.Add(updatedSubRack);
                    }
                }
                await _dbCon.SaveChangesAsync(cancellationToken);
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
