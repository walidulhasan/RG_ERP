using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.Maxco.OrderKnittingSchedulings.Queries.RequestResponseModel;
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
    public class OrderKnittingSchedulingRepository:GenericRepository<OrderKnittingScheduling>, IOrderKnittingSchedulingRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderKnittingSchedulingRepository(MaxcoDBContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<OrderKnittingSchedulingRM>> GetListOrderKnittingScheduling(int krsid, int fabid, CancellationToken cancellationToken)
        {
            try
            {
                var data = (from oks in _dbCon.OrderKnittingScheduling
                            join os in _dbCon.KRS_DETAIL on new {k=oks.KRSID,f=oks.FabID } equals new {k=os.KRS_MID,f=os.FABID }
                            join fq in _dbCon.FabricQuality_Setup on os.QUALITYID equals fq.ID
                            join ft in _dbCon.FabricType_Setup on fq.TypeID equals ft.ID
                            where (oks.IsActive==true && oks.IsRemoved==false && oks.KRSID == krsid && oks.FabID==fabid )
                            select new OrderKnittingSchedulingRM
                            {
                                KnittingScheduleID=oks.KnittingScheduleID,
                                FabID=oks.FabID,
                                KRSID=oks.KRSID,
                                ScheduleDate = oks.ScheduleDate,
                                Quantity=oks.Quantity,
                                ScheduleID=oks.ScheduleID,
                                FabricComposition=os.FAB_COMPOSITION,
                                FabricQuality=fq.Description,
                                FabricType=ft.Description,
                                FinishedWidth=Convert.ToDecimal(os.FINISHED_WIDTH),
                                GSM=os.GSM,
                            }).OrderBy(x => x.ScheduleDate);


                return await data.ToListAsync(cancellationToken);
            }
            catch (System.Exception e)
            {

                throw;
            }
        }
    }
}
