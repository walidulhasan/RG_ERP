using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Maxco.Buisness.OrderSewingSchedulings.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using RG.Infrastructure.Persistence.MaxcoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class OrderSewingSchedulingRepository : GenericRepository<OrderSewingScheduling>, IOrderSewingSchedulingRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderSewingSchedulingRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<OrderSewingSchedulingRM>> GetListSewingScheduling(int OrderId, int GSM, int FabricQualityID, string FabricComposition, string PantoneNo, decimal FinishedWidth, CancellationToken cancellationToken)
        {
            var dataQuery = from os in _dbCon.OrderScheduling
                            join df in _dbCon.OrderSewingScheduling on new { schid = os.ScheduleID, act = true, del = false } equals new { schid = df.ScheduleID, act = df.IsActive, del = df.IsRemoved }
                            join fqs in _dbCon.FabricQuality_Setup on df.FabricQualityID equals fqs.ID
                            join fts in _dbCon.FabricType_Setup on fqs.TypeID equals fts.ID
                            where os.IsRemoved == false &&
                            os.IsActive == true &&
                            os.OrderID == OrderId &&
                            df.GSM == GSM &&
                            df.FabricQualityID == FabricQualityID &&
                            df.FabricComposition == FabricComposition &&
                            df.PantoneNo == PantoneNo &&
                            df.FinishedWidth == FinishedWidth
                            select new OrderSewingSchedulingRM()
                            {
                                SewingScheduleID = df.SewingScheduleID,
                                ScheduleDate = df.ScheduleDate,
                                Quantity = df.Quantity,
                                FabricComposition = df.FabricComposition,
                                GSM = df.GSM,
                                FinishedWidth = df.FinishedWidth,
                                PantoneNo = df.PantoneNo,
                                FabricQualityID = df.FabricQualityID,
                                ScheduleID = os.ScheduleID,
                                FabricQualityDescription = fqs.Description,
                                FabricTypeDescription = fts.Description
                            };
            var data = await dataQuery.ToListAsync(cancellationToken);
            if (data == null)
            {
                data = new List<OrderSewingSchedulingRM>();
            }
            return data;
        }
    }
}
