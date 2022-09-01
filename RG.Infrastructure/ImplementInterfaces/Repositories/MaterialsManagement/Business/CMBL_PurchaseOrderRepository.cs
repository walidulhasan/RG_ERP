using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RG.Application.Common.Utilities;
using RG.Application.Contracts.AlgoHR.Business.SalaryAnalysisDivisions.Query.RequestResponseModel;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.ViewModel.MDSir.CMBLPurchaseOrder;
using RG.DBEntities.MaterialsManagement.Business;
using RG.Infrastructure.Persistence.MaterialsManagementDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.MaterialsManagement.Business
{
    public class CMBL_PurchaseOrderRepository : GenericRepository<CMBL_PurchaseOrder>, ICMBL_PurchaseOrderRepository
    {
        private readonly MaterialsManagementDBContext _dbCon;

        public CMBL_PurchaseOrderRepository(MaterialsManagementDBContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<AnalysisDivisionWiseSalaryRM>> GetAnalysisDivisionWiseCost(string analysisDivision, string departmentGroup, int year, int month, CancellationToken cancellationToken)
        {
            List<AnalysisDivisionWiseSalaryRM> data = new();
            try
            {

                await _dbCon.LoadStoredProc("rpt.USP_AnalysisDivisionWiseCost")
                   .WithSqlParam("AnalysisDivision", analysisDivision)
                    .WithSqlParam("DepartmentGroup ", departmentGroup)
                    .WithSqlParam("Year", year)
                    .WithSqlParam("Month", month)
                                  .ExecuteStoredProcAsync((handler) =>
                                  {
                                      data = handler.ReadToList<AnalysisDivisionWiseSalaryRM>() as List<AnalysisDivisionWiseSalaryRM>;
                                  });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<SelectListItem>> GetDDLPO(int companyID, string predict, CancellationToken cancellationToken)
        {
            try
            {
                // DateTime conditionalDate = new DateTime(2022,8,31);
                DateTime conditionalDate = new DateTime(2022, 8, 01);

                var dataQuery = _dbCon.CMBL_PurchaseOrder
                                .Where(x => x.CompanyID == companyID
                                   && (predict == null || x.PONo.ToString().Contains(predict))
                                   && x.CreationDate >= conditionalDate
                                ).OrderBy(x => x.CreationDate).ThenBy(x => x.PONo)
                                .Select(x => new
                                {
                                    PODate = x.CreationDate.Date,
                                    PONo = x.PONo,
                                    POID = x.POID,
                                    PODateSt = x.CreationDate.ToString("dd-MMM-yyyy")
                                });

                //var queryStr = dataQuery.ToQueryString();
                var parentGroup = await dataQuery
                        .GroupBy(b => new { PODate = b.PODate.Date })
                        .Select(s => new SelectListGroup
                        {
                            Name = s.Key.PODate.ToString("dd-MMM-yyyy")
                        }).ToDictionaryAsync(x => x.Name, StringComparer.Ordinal, cancellationToken);

                var data = await dataQuery.Select(s => new SelectListItem
                {
                    Text = s.PONo.ToString(),
                    Value = s.POID.ToString(),
                    Group = parentGroup[s.PODateSt]
                }).ToListAsync(cancellationToken);

                return data;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<POReportVM> GetPOReportMdSir(long POID, CancellationToken cancellationToken)
        {
            var poInfo = new POReportVM();
            /// PO INFO
            var poInfoQuery = from po in _dbCon.CMBL_PurchaseOrder
                              join us in _dbCon.Vw_User_Setup on po.UserID equals (int)us.ID
                              join sts in _dbCon.CMBL_StatusPO on po.POStatus equals sts.StatusID
                              where po.POID == POID
                              select new POReportVM
                              {
                                  POID = po.POID,
                                  PONO = po.PONo,
                                  LCNo = po.LCNumber,
                                  PaymentMode = po.PaymentMode,
                                  PaymentTerm = po.PaymentTerm,
                                  PODate = po.CreationDate.ToString("dd-MMM-yyyy hh:mm tt"),
                                  AdvancePercentage = po.advance_percentage,
                                  CompanyID = po.CompanyID.Value,
                                  SupplierId = po.SupplierID.Value,
                                  POStatus = sts.Description,
                                  UserName = us.FullName.Length > 0 ? us.FullName : us.UserName,
                              };
            poInfo = await poInfoQuery.FirstAsync(cancellationToken);

            // Supplier Info
            var supplierInfo = await _dbCon.Viw_Supplier.Where(b => b.SupplierID == poInfo.SupplierId)
                .Select(s => new POSupplierInfoVM
                {
                    SupplierID = s.SupplierID,
                    SupplierAddress = s.Address,
                    SupplierEmail = s.Email,
                    SupplierMobileNo = s.MobileNumber,
                    SupplierName = s.CompanyName,
                    SupplierPhoneNo = s.TelephoneNumber
                }).FirstOrDefaultAsync(cancellationToken);

            poInfo.POSupplierInfo = new POSupplierInfoVM();
            poInfo.POSupplierInfo = supplierInfo;

            //COmpany INFO
            var companyInfo = await _dbCon.Vw_CompanyInfo.Where(b => b.CompanyID == poInfo.CompanyID)
                .Select(s => new POCompanyInfoVM
                {
                    CompanyName = s.Companyname,
                    CompanyAddress = s.Address,
                    FactoryAddress = s.MainFactoryAddress
                }).FirstOrDefaultAsync(cancellationToken);

            poInfo.POCompanyInfo = new POCompanyInfoVM();
            poInfo.POCompanyInfo = companyInfo;

            //requisition INFO
            var requisitionQuery = from po in _dbCon.CMBL_PurchaseOrder
                                   join poItm in _dbCon.CMBL_PurchaseOrderItem on po.POID equals poItm.POID
                                   join rd in _dbCon.CMBL_ItemRequisitionRequirement on poItm.RequisitionDetailID equals rd.IRRID
                                   join rm in _dbCon.CMBL_ItemRequisitionMaster on rd.IRID equals rm.IRID
                                   join us in _dbCon.Vw_User_Setup on rm.UserID equals (int)us.ID
                                   join buOrd in _dbCon.Vw_BuyerOrder on rd.OrderID equals (int)buOrd.OrderID into _buOrdJ
                                   from ord in _buOrdJ.DefaultIfEmpty()
                                   where po.POID == POID
                                   group new { rm, ord, us, rd } by new
                                   {
                                       IRID = rm.IRID,
                                       CreationDate = rm.CreationDate.Date,
                                       BuyerName = ord.BuyerName,
                                       OrderNo = ord.OrderNo,
                                       CreatorComments = rm.CreatorComments,
                                       IRCode = rm.IRCode,
                                       FullName = us.FullName,
                                       UserName = us.UserName
                                   } into grp
                                   select new PORequisitionVM
                                   {
                                       IRID = grp.Key.IRID,
                                       RequisitionDate = grp.Key.CreationDate,
                                       Buyer = grp.Key.BuyerName != null ? grp.Key.BuyerName : "",
                                       OrderNo = grp.Key.OrderNo != null ? grp.Key.OrderNo : "",
                                       RequisitionComments = grp.Key.CreatorComments,
                                       RequisitionNo = grp.Key.IRCode,
                                       UserName = grp.Key.FullName.Length > 0 ? grp.Key.FullName : grp.Key.UserName,

                                   };
            var requisitionData = await requisitionQuery.ToListAsync(cancellationToken);

            poInfo.PORequisition = new List<PORequisitionVM>();
            poInfo.PORequisition = requisitionData;

            ///Po Items
            var PoItemsQuery = from po in _dbCon.CMBL_PurchaseOrder
                               join poItm in _dbCon.CMBL_PurchaseOrderItem on po.POID equals poItm.POID
                               join rd in _dbCon.CMBL_ItemRequisitionRequirement on poItm.RequisitionDetailID equals rd.IRRID
                               join rm in _dbCon.CMBL_ItemRequisitionMaster on rd.IRID equals rm.IRID
                               join us in _dbCon.Vw_User_Setup on rm.UserID equals (int)us.ID
                               join itm in _dbCon.vw_CMBL_ItemALLAttribute on poItm.ItemID equals itm.ItemID
                               join unt in _dbCon.CMBL_Unit on poItm.UnitID equals unt.UnitID
                               join cur in _dbCon.Vw_Currency on poItm.FCID equals cur.ID
                               where po.POID == POID
                               group new { po, poItm, rm, us, itm, unt } by new
                               {
                                   POID = po.POID,
                                   rm.IRCode,
                                   itm.ItemName,
                                   itm.L_1_AttributeName,
                                   itm.L_2_AttributeName,
                                   itm.L_3_AttributeName,
                                   DeliveryDate = poItm.DeliveryDate.Date,
                                   Quantity = poItm.Quantity,
                                   Unit = unt.UnitAbbreviation,
                                   Rate = poItm.Rate,
                                   CurrencyShort = cur.ShortName,
                                   CurrencySymbol = cur.Symbol,
                                   FullName = us.FullName,
                                   UserName = us.UserName
                               } into grp
                               select new POItemVM
                               {
                                   POID = grp.Key.POID,
                                   RequisitionNo = grp.Key.IRCode,
                                   UserName = grp.Key.FullName.Length > 0 ? grp.Key.FullName : grp.Key.UserName,
                                   ItemName = grp.Key.ItemName,
                                   Category = $"{grp.Key.L_1_AttributeName}->{grp.Key.L_2_AttributeName}->{grp.Key.L_3_AttributeName}",
                                   DeliveryDate = grp.Key.DeliveryDate,
                                   Quantity = (decimal)grp.Key.Quantity,
                                   Rate = (decimal)grp.Key.Rate,
                                   Unit = grp.Key.Unit
                               };
            var poItemsData = await PoItemsQuery.ToListAsync(cancellationToken);
            poInfo.POItem = new List<POItemVM>();
            poInfo.POItem = poItemsData;

            //Delivery Point Comma Seperat 
            var deliveryPoints = await (from poit in _dbCon.CMBL_PurchaseOrderItem
                                        join dd in _dbCon.DDDeliveryPoint_Setup on poit.DeliveryPoint equals dd.ID
                                        where poit.POID==POID
                                        group dd by dd.Description into grp
                                        select new
                                        {
                                            grp.Key
                                        }).ToListAsync(cancellationToken);

            var DeliveryLocation = deliveryPoints.Select(s => s.Key).Aggregate((f, l) => f + "," + l);

            poInfo.DeliveryLocation = DeliveryLocation;

            /// Po  Quation File
            var poquotationFile = await _dbCon.CMBL_POQuotationFileUpload
                .Where(b => b.POID == POID)
                 .Select(s => new POQuotationFile
                 {
                     POAttachmentID= s.POAttachmentID,
                     POID=s.POID,
                     Comments=s.Comments,
                     FileName=s.FileName,
                     FileSerial=s.FileSerial,
                     FileUri=s.FileUri,
                     UploadDate=s.UploadDate
                 }).ToListAsync(cancellationToken);
            poInfo.POQuotationFile = new List<POQuotationFile>();
            poInfo.POQuotationFile = poquotationFile;

            return poInfo;

        }
    }
}
