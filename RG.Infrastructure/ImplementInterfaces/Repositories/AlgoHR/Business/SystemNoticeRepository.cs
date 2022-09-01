using Microsoft.EntityFrameworkCore;
using RG.Application.Common.CommonInterfaces;
using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Setups.SystemNotices.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class SystemNoticeRepository : GenericRepository<SystemNotice>, ISystemNoticeRepository
    {
        private AlgoHRDBContext dbCon;


        public SystemNoticeRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<SystemNoticeRM>> GetAllNotices(int companyID, int divisionID, int departmentID, int sectionID)
        {
            List<SystemNoticeRM> notices = new();
            try
            {
                await dbCon.LoadStoredProc("ajt.Usp_GetCurrentNotices")
                    .WithSqlParam("CompanyID", companyID)
                    .WithSqlParam("DivisionID", divisionID)
                    .WithSqlParam("DepartmentID", departmentID)
                    .WithSqlParam("SectionID", sectionID)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      notices = handler.ReadToList<SystemNoticeRM>() as List<SystemNoticeRM>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return notices;
        }

        public IQueryable<SystemNoticeRM> GetNoticeList(CancellationToken cancellationToken)
        {
            var data = dbCon.SystemNotice
                .Where(x => x.IsActive == true && x.IsRemoved == false)
                .Select(row => new SystemNoticeRM
                {
                    NoticeID = row.NoticeID,
                    NoticeTitle = row.NoticeTitle,
                    NoticeDescription = row.NoticeDescription,
                    ValidDateFromMsg = row.ValidDateFrom.ToString("dd-MMM-yyyy hh:mm tt"),
                    ValidDateToMsg = row.ValidDateTo.ToString("dd-MMM-yyyy hh:mm tt")
                });
            return data;
        }

        public async Task<SystemNotice> GetSystemNotice(int noticeID,CancellationToken cancellationToken)
        {
            var entity = await dbCon.SystemNotice

                .Where(x => x.NoticeID == noticeID && x.IsActive == true && x.IsRemoved == false)
                .Include(x=>x.CustomCasting.Where(y=>y.IsActive==true && y.IsRemoved==false))
                .FirstAsync(cancellationToken);
            return entity;
        }

        public async Task<RResult> SystemNoticeSave(SystemNotice notice)
        {
            RResult rResult = new();
            await dbCon.SystemNotice.AddAsync(notice);
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.InsertMessage;
            return rResult;
        }

        public async Task<RResult> SystemNoticeUpdate(SystemNotice notice)
        {
            RResult rResult = new();
            dbCon.SystemNotice.Update(notice);
            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            if (notice.IsRemoved)
                rResult.message = ReturnMessage.DeleteMessage;
            return rResult;
        }
    }
}
