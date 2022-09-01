using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.EMS.Business;
using RG.Infrastructure.Persistence.EMSDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.EMS.Business
{
    public class ExportDocumensRepository : IExportDocumensRepository
    {
        private readonly EMSDBContext _dbCon;

        public ExportDocumensRepository(EMSDBContext dbCon) //: base(dbCon)
        {
            _dbCon = dbCon;
        }

        public async Task<List<DocumentsPurchaseRatioRM>> GetDocumentsPurchaseRatio(DateTime? dateFrom, DateTime? dateTo, bool withPurchaseRatio, CancellationToken cancellationToken)
        {
            var data = new List<DocumentsPurchaseRatioRM>();
            
            try
            {
                await _dbCon.LoadStoredProc("rpt.usp_FDBP_Document", commandTimeout: 300)

                .WithSqlParam("DateFrom", dateFrom)
                .WithSqlParam("DateTo", dateTo)
                .WithSqlParam("WithPurchaseRatio", withPurchaseRatio)

                .ExecuteStoredProcAsync((handler) =>
                {
                    data = handler.ReadToList<DocumentsPurchaseRatioRM>() as List<DocumentsPurchaseRatioRM>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<ExportDocumentRealizationRM>> GetExportDocumentRealizationData(int isDetailsReport, int fDBPP_ID = 0)
        {
            var data = new List<ExportDocumentRealizationRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Usp_ExportDocumentRealization",commandTimeout:500)
                                .WithSqlParam("IsDetailsReport", isDetailsReport)
                                .WithSqlParam("FDBPP_ID", fDBPP_ID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<ExportDocumentRealizationRM>() as List<ExportDocumentRealizationRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<LCMaturityRealizeRM>> GetLCMaturityRealize(int FilterTypeId, DateTime DateFrom, DateTime DateTo, int Month, int Year, int CompanyId = 0, int FundTypeID = 0)
        {
            var data = new List<LCMaturityRealizeRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Usp_LCMaturityRealize", commandTimeout: 300)
                                .WithSqlParam("FilterTypeId", FilterTypeId)
                                .WithSqlParam("DateFrom", DateFrom)
                                .WithSqlParam("DateTo", DateTo)
                                .WithSqlParam("Month", Month)
                                .WithSqlParam("Year", Year)
                                .WithSqlParam("CompanyId", CompanyId)
                                .WithSqlParam("FundTypeID", FundTypeID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<LCMaturityRealizeRM>() as List<LCMaturityRealizeRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<LCMaturityRealizeRM>> GetOutstandingLCRealization(int year, int companyId, int fundTypeID)
        {
            var data = new List<LCMaturityRealizeRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.Usp_OutstandingLCRealize", commandTimeout: 300)

                                .WithSqlParam("Year", year)
                                .WithSqlParam("CompanyId", companyId)
                                .WithSqlParam("FundTypeID", fundTypeID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<LCMaturityRealizeRM>() as List<LCMaturityRealizeRM>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<WeeklyExportDetailsReportRM>> GetPaymentNotReceivedWithinExpectedDateReportData(DateTime exFactoryDateTo)
        {
            var data = new List<WeeklyExportDetailsReportRM>();
            DateTime exFactoryDateFrom = new DateTime(2022, 6, 1);
            try
            {
                await _dbCon.LoadStoredProc("rpt.USP_InvoiceShipmentPaymentNotReceivedExpectedDate", commandTimeout: 300)

                .WithSqlParam("ExfactoryDateFrom", exFactoryDateFrom)
                .WithSqlParam("ExfactoryDateTo", exFactoryDateTo)
                
                .ExecuteStoredProcAsync((handler) =>
                {
                    data = handler.ReadToList<WeeklyExportDetailsReportRM>() as List<WeeklyExportDetailsReportRM>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<WeeklyExportDetailsReportRM>> GetWeeklyExportDetailsReportData(DateTime exFactoryDateFrom, DateTime exFactoryDateTo, int companyID, int buyerID, int orderID)
        {
            var data = new List<WeeklyExportDetailsReportRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.USP_InvoiceShipmentStatus", commandTimeout: 300)

                .WithSqlParam("ExfactoryDateFrom", exFactoryDateFrom)
                .WithSqlParam("ExfactoryDateTo", exFactoryDateTo)
                .WithSqlParam("CompanyID", companyID)
                .WithSqlParam("BuyerID", buyerID)
                .WithSqlParam("OrderID", orderID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    data = handler.ReadToList<WeeklyExportDetailsReportRM>() as List<WeeklyExportDetailsReportRM>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<WeeklyShipmentStatusRM>> GetWeeklyShipmentStatusReportData(int year, int month, int week, CancellationToken cancellationToken)
        {
            var data = new List<WeeklyShipmentStatusRM>();
            try
            {
                await _dbCon.LoadStoredProc("rpt.USP_WeeklyShipmentSummary", commandTimeout: 300)

                .WithSqlParam("Year", year)
                .WithSqlParam("Month", month)
                .WithSqlParam("WeekPeriodID", week)
                //.WithSqlParam("BuyerID", buyerID)
                //.WithSqlParam("OrderID", orderID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    data = handler.ReadToList<WeeklyShipmentStatusRM>() as List<WeeklyShipmentStatusRM>;
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }
    }
}
