using RG.Application.Contracts.EMS.Business.ExportDocuments.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.EMS.Business;
using RG.Application.Interfaces.Services.EMS.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.EMS.Business
{
    public class ExportDocumentsService : IExportDocumentsService
    {
        private readonly IExportDocumensRepository _exportDocumensRepository;

        public ExportDocumentsService(IExportDocumensRepository exportDocumensRepository)
        {
            _exportDocumensRepository = exportDocumensRepository;
        }

        public async Task<List<DocumentsPurchaseRatioRM>> GetDocumentsPurchaseRatio(DateTime? dateFrom, DateTime? dateTo, bool withPurchaseRatio, CancellationToken cancellationToken)
        {
            return await _exportDocumensRepository.GetDocumentsPurchaseRatio(dateFrom, dateTo, withPurchaseRatio, cancellationToken);
        }

        public async Task<List<ExportDocumentRealizationRM>> GetExportDocumentRealizationData(int isDetailsReport, int fDBPP_ID = 0)
        {
            return await _exportDocumensRepository.GetExportDocumentRealizationData(isDetailsReport, fDBPP_ID);
        }

        public async Task<List<LCMaturityRealizeRM>> GetLCMaturityRealize(int FilterTypeId, DateTime DateFrom, DateTime DateTo, int Month, int Year, int CompanyId = 0, int FundTypeID = 0)
        {
            return await _exportDocumensRepository.GetLCMaturityRealize(FilterTypeId, DateFrom,DateTo,Month,Year,CompanyId,FundTypeID);
        }

        public async Task<List<LCMaturityRealizeRM>> GetOutstandingLCRealization(int year, int companyId, int fundTypeID)
        {
            return await _exportDocumensRepository.GetOutstandingLCRealization(year, companyId, fundTypeID);
        }

        public async Task<List<WeeklyExportDetailsReportRM>> GetPaymentNotReceivedWithinExpectedDateReportData(DateTime exFactoryDateTo)
        {
            return await _exportDocumensRepository.GetPaymentNotReceivedWithinExpectedDateReportData( exFactoryDateTo);
        }

        public async Task<List<WeeklyExportDetailsReportRM>> GetWeeklyExportDetailsReportData(DateTime exFactoryDateFrom, DateTime exFactoryDateTo, int companyID, int buyerID, int orderID)
        {
            return await _exportDocumensRepository.GetWeeklyExportDetailsReportData(exFactoryDateFrom, exFactoryDateTo, companyID, buyerID, orderID);
        }

        public async Task<List<WeeklyShipmentStatusRM>> GetWeeklyShipmentStatusReportData(int year, int month, int week, CancellationToken cancellationToken)
        {
            return await _exportDocumensRepository.GetWeeklyShipmentStatusReportData(year,month,week, cancellationToken);
        }
    }
}
