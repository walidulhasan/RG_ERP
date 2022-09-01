
using RG.Application.Contracts.AlgoHR.Setups.CompanyKPIParticularss.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Setup;
using RG.DBEntities.AlgoHR.Setup;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Setup
{
    public class CompanyKPIParticularsRepository : GenericRepository<CompanyKPIParticulars>, ICompanyKPIParticularsRepository
    {
        private readonly AlgoHRDBContext dbCon;

        public CompanyKPIParticularsRepository(AlgoHRDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<List<CompanyKPIParticularsRM>> GetAllCompanyKPIParticulars(int kpiMonth, int kpiYear, CancellationToken cancellationToken)
        {
            var data = await (from p in dbCon.CompanyKPIParticulars
                              join pv in dbCon.KPIParticularValues on new { ParticularID = p.ID, IsActive = true, IsRemoved = false, KPIMonth = kpiMonth, KPIYear = kpiYear } equals new { pv.ParticularID, pv.IsActive, pv.IsRemoved, pv.KPIMonth, pv.KPIYear } into leftj
                              from leftJoin in leftj.DefaultIfEmpty()
                              select new CompanyKPIParticularsRM
                              {
                                  ID = p.ID,
                                  ParticularHead = p.ParticularHead,
                                  Particulars = p.Particulars,
                                  Serial = p.Serial,
                                  AutoCalculation = p.AutoCalculation,
                                  ParticularValueID = leftJoin != null ? leftJoin.ID : 0,
                                  ParticularValue = leftJoin != null ? leftJoin.ParticularValue : 0,
                                  IsCalculationParticular = leftJoin != null ? leftJoin.IsCalculationParticular : false
                              }).OrderBy(x => x.Serial).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<CompanyKPIReportRM>> GetAllCompanyKPIParticularsReport(int kpiMonth, int kpiYear, int forLastYears, CancellationToken cancellationToken)
        {
            List<int> YearList = new();
            YearList.Add(kpiYear);
            for (int i = 1; i <= forLastYears; i++)
            {
                var year = kpiYear - i;
                YearList.Add(year);
            }

            /*
            
            var dataQuery =  from p in dbCon.CompanyKPIParticulars
                              join pv in dbCon.KPIParticularValues on new { ParticularID = p.ID, IsActive = true, IsRemoved = false,} 
                                                                    equals new { pv.ParticularID, pv.IsActive, pv.IsRemoved, } into leftj
                              from leftJoin in leftj.DefaultIfEmpty()                              
                              select new CompanyKPIReportRM
                              {
                                  ID = p.ID,
                                  ParticularHead = p.ParticularHead,
                                  Particulars = p.Particulars,
                                  Serial = p.Serial,
                                  DecimalUpTo=p.DecimalUpTo,
                                  AutoCalculation = p.AutoCalculation,
                                  ParticularValueID = leftJoin != null ? leftJoin.ID : 0,
                                  ParticularValue = leftJoin != null ? leftJoin.ParticularValue : 0,
                                  IsCalculationParticular = leftJoin != null && leftJoin.IsCalculationParticular,
                                  KPIMonth = leftJoin != null ? leftJoin.KPIMonth : 0,
                                  KPIYear = leftJoin != null ? leftJoin.KPIYear : 0,
                              };
            var aa = dataQuery.ToQueryString();
            if (kpiMonth == 0)
            {
                dataQuery = dataQuery.Where(x =>(x.KPIYear == 0|| x.KPIYear == kpiYear));
            }
            var ba = dataQuery.ToQueryString();
            if (forLastYears > 0)
            {
                dataQuery = dataQuery.Where(x => x.KPIYear == 0 || YearList.Contains(x.KPIYear));
            }
            var Ca = dataQuery.ToQueryString();
            if (kpiMonth > 0)
            {
                dataQuery = dataQuery.Where(x => (x.KPIMonth == 0 || x.KPIMonth == kpiMonth));
            }
           
            var sq = dataQuery.ToQueryString();
               */
            var dataQueryValue = dbCon.KPIParticularValues.Where(v => v.IsRemoved == false && v.IsActive == true)
                                 .Select(s => new
                                 {
                                     ParticularID = s.ParticularID,
                                     ParticularValueID = s.ID,
                                     ParticularValue = s.ParticularValue,
                                     IsCalculationParticular = s.IsCalculationParticular,
                                     KPIMonth = s.KPIMonth,
                                     KPIYear = s.KPIYear,
                                 });
            if (kpiMonth == 0)
            {
                dataQueryValue = dataQueryValue.Where(x => (x.KPIYear == 0 || x.KPIYear == kpiYear));
            }
            var ba = dataQueryValue.ToQueryString();
            if (forLastYears > 0)
            {
                dataQueryValue = dataQueryValue.Where(x => x.KPIYear == 0 || YearList.Contains(x.KPIYear));
            }
            var Ca = dataQueryValue.ToQueryString();
            if (kpiMonth > 0)
            {
                dataQueryValue = dataQueryValue.Where(x => (x.KPIMonth == 0 || x.KPIMonth == kpiMonth));
            }
            var da = dataQueryValue.ToQueryString();

            var kpiValue = await dataQueryValue.ToListAsync(cancellationToken);

            var kpiParticular = await dbCon.CompanyKPIParticulars.Where(b => b.IsRemoved == false && b.IsActive == true)
                .Select(p => new CompanyKPIReportRM()
                {
                    ID = p.ID,
                    ParticularHead = p.ParticularHead,
                    Particulars = p.Particulars,
                    Serial = p.Serial,
                    DecimalUpTo = p.DecimalUpTo,
                    AutoCalculation = p.AutoCalculation,
                }).ToListAsync(cancellationToken);

            var dataQuery = (from p in kpiParticular
                             join pv in kpiValue on p.ID equals pv.ParticularID into leftj
                             from leftJoin in leftj.DefaultIfEmpty()
                             select new CompanyKPIReportRM
                             {
                                 ID = p.ID,
                                 ParticularHead = p.ParticularHead,
                                 Particulars = p.Particulars,
                                 Serial = p.Serial,
                                 DecimalUpTo = p.DecimalUpTo,
                                 AutoCalculation = p.AutoCalculation,
                                 ParticularValueID = leftJoin != null ? leftJoin.ParticularValueID : 0,
                                 ParticularValue = leftJoin != null ? leftJoin.ParticularValue : 0,
                                 IsCalculationParticular = (leftJoin != null && leftJoin.IsCalculationParticular) ? true : false,
                                 KPIMonth = leftJoin != null ? leftJoin.KPIMonth : 0,
                                 KPIYear = leftJoin != null ? leftJoin.KPIYear : 0,
                             });

            try
            {
                var data =   dataQuery.ToList();

                if (data.Where(x => x.KPIMonth > 0).ToList().Count() == 0)
                {
                    data.ForEach(x => { x.KPIMonth = kpiMonth; x.KPIYear = kpiYear; });
                }

                return data;
            }
            catch (Exception e)
            {
                var bbb = e.Message;
                return new List<CompanyKPIReportRM>();
            }
        }
    }
}
