using Microsoft.EntityFrameworkCore;
using RG.Application.Contracts.AlgoHR.Business.CompanyMonthlySalarys.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AlgoHR.Business;
using RG.DBEntities.AlgoHR.Business;
using RG.Infrastructure.Persistence.AlgoHRDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AlgoHR.Business
{
    public class CompanyMonthlySalaryRepository : GenericRepository<CompanyMonthlySalary>, ICompanyMonthlySalaryRepository
    {
        private readonly AlgoHRDBContext _dbCon;

        public CompanyMonthlySalaryRepository(AlgoHRDBContext context) : base(context)
        {
            _dbCon = context;
        }

        public async Task<List<CompanyMonthlySalaryRM>> GetCompanyMonthlySalary(int CompanyId, int Month, int Year, CancellationToken cancellationToken)
        {
            List<CompanyMonthlySalaryRM> datas = new List<CompanyMonthlySalaryRM>();
            try
            {
                datas = await _dbCon.CompanyMonthlySalary.Where(x => (CompanyId == 0 || x.CompanyID == CompanyId) && (Month == 0 || x.SalaryMonth == Month) && x.SalaryYear == Year)
                     .GroupBy(x=> new { x.CompanyID, x.CompanyName,x.DivisionID,x.DivisionName,x.SalaryYear,x.SalaryMonth,x.SalaryMonthName})
                    .Select(x => new CompanyMonthlySalaryRM
                     {
                         CompanyID = x.Key.CompanyID,
                         CompanyName = x.Key.CompanyName,
                         DivisionID = x.Key.DivisionID,
                         DivisionName = x.Key.DivisionName,
                         SalaryYear = x.Key.SalaryYear,
                         SalaryMonth=x.Key.SalaryMonth,
                         SalaryMonthName=x.Key.SalaryMonthName,
                         NoOfEmployee = x.Sum(y=>y.NoOfEmployee),
                         GrossSalary = x.Sum(y => y.GrossSalary),
                         PaidSalary = x.Sum(y => y.PaidSalary),
                         GeneralOT = x.Sum(y => y.GeneralOT),
                         ExtOT = x.Sum(y => y.ExtOT),
                         MobileInternetAllowance = x.Sum(y => y.MobileInternetAllowance),
                         FoodTransportAllowance = x.Sum(y => y.FoodTransportAllowance),
                         CarAllowance = x.Sum(y => y.CarAllowance),
                         FridayAllowance = x.Sum(y => y.FridayAllowance),
                         ProductionBonus = x.Sum(y => y.ProductionBonus),
                         DoubleMachineBonous = x.Sum(y => y.DoubleMachineBonous),
                         EarnLeave = x.Sum(y => y.EarnLeave),
                         MaternityLeave = x.Sum(y => y.MaternityLeave),
                         ServiceBenefit = x.Sum(y => y.ServiceBenefit),
                         HolidayAllowance = x.Sum(y => y.HolidayAllowance),
                         ArrearAllowance = x.Sum(y => y.ArrearAllowance),
                         ExtraAllowance = x.Sum(y => y.ExtraAllowance)
                     })
                     .ToListAsync(cancellationToken);
                
                if (datas.Count == 0)
                {
                    List<CompanyMonthlySalaryRM> data = GetDummyData();
                    datas = data.Where(x => (CompanyId == 0 || x.CompanyID == CompanyId)
                                         && (Month == 0 || x.SalaryMonth == Month)
                                         && x.SalaryYear == Year)
                                .ToList();
              
                }
                return datas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        private static List<CompanyMonthlySalaryRM> GetDummyData()
        {
            List<CompanyMonthlySalaryRM> data = new List<CompanyMonthlySalaryRM>()
            {
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL",DivisionName="HO",NoOfEmployee=10,GrossSalary=12 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL",DivisionName="Textile",NoOfEmployee=10 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL", DivisionName="Peinting",NoOfEmployee=12},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL",DivisionName="Garments" },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL", DivisionName="AOP"},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="RBL",DivisionName="Boutiques" },

                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="CBL", DivisionName="HO",NoOfEmployee=11,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="CBL",DivisionName="Textile" ,NoOfEmployee=10,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="CBL",DivisionName="MS Lario" },
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=1,SalaryMonthName="January",SalaryYear=2022,CompanyName="CBL",DivisionName="Garments" },


                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL",DivisionName="HO",NoOfEmployee=10,GrossSalary=12 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL",DivisionName="Textile",NoOfEmployee=10 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL", DivisionName="Peinting",NoOfEmployee=12},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL",DivisionName="Garments" },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL", DivisionName="AOP"},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="RBL",DivisionName="Boutiques" },

                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="CBL", DivisionName="HO",NoOfEmployee=11,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="CBL",DivisionName="Textile" ,NoOfEmployee=10,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="CBL",DivisionName="MS Lario" },
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=2,SalaryMonthName="February",SalaryYear=2022,CompanyName="CBL",DivisionName="Garments" },

                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March", SalaryYear=2022,CompanyName="RBL",DivisionName="HO",NoOfEmployee=10,GrossSalary=12 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="RBL",DivisionName="Textile",NoOfEmployee=10 },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="RBL", DivisionName="Peinting",NoOfEmployee=12},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="RBL",DivisionName="Garments" },
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="RBL", DivisionName="AOP"},
                new CompanyMonthlySalaryRM{CompanyID=183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="RBL",DivisionName="Boutiques" },

                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="CBL", DivisionName="HO",NoOfEmployee=11,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="CBL",DivisionName="Textile" ,NoOfEmployee=10,GrossSalary=12},
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="CBL",DivisionName="MS Lario" },
                new CompanyMonthlySalaryRM{CompanyID=20183,SalaryMonth=3,SalaryMonthName="March",SalaryYear=2022,CompanyName="CBL",DivisionName="Garments" },

            };
            return data;
        }

        public async Task<List<CompanyMonthlySalaryRM>> GetCompanyDivisionMonthlySalary(int CompanyId, int DivisionID, int Month, int Year, CancellationToken cancellationToken)
        {
            List<CompanyMonthlySalaryRM> datas = new List<CompanyMonthlySalaryRM>();
            try
            {
                datas = await _dbCon.CompanyMonthlySalary.Where(x => (CompanyId == 0 || x.CompanyID == CompanyId)
                                                    && (DivisionID==0||x.DivisionID==DivisionID)
                                                    && (Month == 0 || x.SalaryMonth == Month) && x.SalaryYear == Year)
                                                         .GroupBy(x => new { x.CompanyID, x.CompanyName, x.DivisionID, x.DivisionName,x.DepartmentID,x.DepartmentName, x.SalaryYear, x.SalaryMonthName })
                    .Select(x => new CompanyMonthlySalaryRM
                    {
                        CompanyID = x.Key.CompanyID,
                        CompanyName = x.Key.CompanyName,
                        DivisionID = x.Key.DivisionID,
                        DivisionName = x.Key.DivisionName,
                        DepartmentID=x.Key.DepartmentID,
                        DepartmentName=x.Key.DepartmentName,
                        SalaryYear = x.Key.SalaryYear,
                        SalaryMonthName = x.Key.SalaryMonthName,
                        NoOfEmployee = x.Sum(y => y.NoOfEmployee),
                        GrossSalary = x.Sum(y => y.GrossSalary),
                        PaidSalary = x.Sum(y => y.PaidSalary),
                        GeneralOT = x.Sum(y => y.GeneralOT),
                        ExtOT = x.Sum(y => y.ExtOT),
                        MobileInternetAllowance = x.Sum(y => y.MobileInternetAllowance),
                        FoodTransportAllowance = x.Sum(y => y.FoodTransportAllowance),
                        CarAllowance = x.Sum(y => y.CarAllowance),
                        FridayAllowance = x.Sum(y => y.FridayAllowance),
                        ProductionBonus = x.Sum(y => y.ProductionBonus),
                        DoubleMachineBonous = x.Sum(y => y.DoubleMachineBonous),
                        EarnLeave = x.Sum(y => y.EarnLeave),
                        MaternityLeave = x.Sum(y => y.MaternityLeave),
                        ServiceBenefit = x.Sum(y => y.ServiceBenefit),
                        HolidayAllowance = x.Sum(y => y.HolidayAllowance),
                        ArrearAllowance = x.Sum(y => y.ArrearAllowance),
                        ExtraAllowance = x.Sum(y => y.ExtraAllowance)
                    })
                     .ToListAsync(cancellationToken);
                
                if (datas.Count == 0)
                {
                    List<CompanyMonthlySalaryRM> data = GetDummyData();
                    datas = data.Where(x => (CompanyId == 0 || x.CompanyID == CompanyId)
                                         && (Month == 0 || x.SalaryMonth == Month)
                                         && x.SalaryYear == Year)
                                .ToList();

                }
                return datas;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
