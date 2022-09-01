using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.DBEntities.Maxco.Setup;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Setup
{
    public class CuttingAdditionFabricRequiredRepository : GenericRepository<CuttingAdditionFabricRequired>, ICuttingAdditionFabricRequiredRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public CuttingAdditionFabricRequiredRepository(MaxcoDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public IQueryable<CuttingAdditionFabricRM> GetCuttingAdditionFabricRequiredList(DateTime DateFrom, DateTime DateTo, int BuyerId = 0, long OrderID = 0)
        {
            var query = from ca in _dbCon.CuttingAdditionFabricRequired
                        join o in _dbCon.Style on ca.OrderID equals o.ID
                        join col in _dbCon.Collection on o.CollectionID equals col.ID
                        join buy in _dbCon.Buyer_Setup on col.BuyerID equals buy.ID
                        where ca.IsRemoved == false && ca.IsActive == true
                        && ca.RequisitionDate >= DateFrom
                        && ca.RequisitionDate <= DateTo
                        select new CuttingAdditionFabricRM()
                        {
                            ID = ca.ID,
                            BuyerId = buy.ID,
                            BuyerName = buy.Description.Trim(),
                            OrderID = o.ID,
                            OrderNo = o.OrderNo.Trim(),
                            PlanQuantity = ca.PlanQuantity,
                            RequisitionDate = ca.RequisitionDate,
                            RequisitionQuantity = ca.RequisitionQuantity,
                            //OverAllEfficiencyPercent =ca.OverAllEfficiencyPercent,
                            //StandardEfficiencyPercent=ca.StandardEfficiencyPercent

                        };

            if (BuyerId > 0)
            {
                query = query.Where(b => b.BuyerId == BuyerId);
            }
            if (OrderID > 0)
            {
                query = query.Where(b => b.OrderID == OrderID);
            }

            var que = query.ToQueryString();
            return query;


        }

        //public async Task<RResult> SaveAndUpdate(CuttingAdditionFabricRequired entity, bool saveChange)
        //{
        //    RResult result = new();
        //    if (entity.ID == 0)
        //    {
        //        await _dbCon.CuttingAdditionFabricRequired.AddAsync(entity);
        //        await _dbCon.SaveChangesAsync();
        //        result.result = 1;
        //        result.message = "Successfully Insert Cutting Required.";
        //    }
        //    else
        //    {
        //        var dbEntity = await GetByIdAsync(entity.ID);

        //        dbEntity.OrderID = entity.OrderID;
        //        dbEntity.PlanQuantity = entity.PlanQuantity;
        //        dbEntity.RequisitionDate = entity.RequisitionDate;
        //        dbEntity.RequisitionQuantity = entity.RequisitionQuantity;

        //        _dbCon.CuttingAdditionFabricRequired.Update(dbEntity);
        //        await _dbCon.SaveChangesAsync();
        //        result.result = 1;
        //        result.message = "Successfully Update Cutting Required.";

        //    }
        //    return result;
        //}

        //public async Task<RResult> UpdateCuttingAdditionFabricRequired(CuttingAdditionFabricRequired model, bool saveChange)
        //{
        //    var rResult = new RResult();
        //    try
        //    {
        //        await UpdateAsync(model, saveChange);
        //        rResult.result = 1;
        //        rResult.message = ReturnMessage.UpdateMessage;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new(e.Message);
        //    }
        //    return rResult;
        //}
    }
}
