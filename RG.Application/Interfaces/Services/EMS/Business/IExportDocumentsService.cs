using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.EMS.Business
{
    public interface IExportDocumentsService
    {
        Task<List<ExportDocumentRealizationRM>> GetExportDocumentRealizationData(int isDetailsReport, int fDBPP_ID = 0);
        Task<List<LCMaturityRealizeRM>> GetLCMaturityRealize(int FilterTypeId, DateTime DateFrom, DateTime DateTo, int Month, int Year, int CompanyId = 0, int FundTypeID = 0);
        Task<List<LCMaturityRealizeRM>> GetOutstandingLCRealization(int year, int companyId, int fundTypeID);
        Task<List<WeeklyExportDetailsReportRM>> GetWeeklyExportDetailsReportData(DateTime exFactoryDateFrom, DateTime exFactoryDateTo, int companyID, int buyerID, int orderID);
        Task<List<WeeklyExportDetailsReportRM>> GetPaymentNotReceivedWithinExpectedDateReportData( DateTime exFactoryDateTo);
        Task<List<WeeklyShipmentStatusRM>> GetWeeklyShipmentStatusReportData(int year, int month, int week, CancellationToken cancellationToken);
        Task<List<DocumentsPurchaseRatioRM>> GetDocumentsPurchaseRatio(DateTime? dateFrom, DateTime? dateTo, bool withPurchaseRatio, CancellationToken cancellationToken);
    }
}
