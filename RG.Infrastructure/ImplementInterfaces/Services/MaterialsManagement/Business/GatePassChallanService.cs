using Microsoft.AspNetCore.Identity;
using RG.Application.Common.Utilities;
using RG.Application.IdentityEntities;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.Application.Interfaces.Repositories.Embro.Setups;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Business;
using RG.Application.Interfaces.Repositories.MaterialsManagement.DbViews;
using RG.Application.Interfaces.Repositories.MaterialsManagement.Setups;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Repositories.Maxco.Setup;
using RG.Application.Interfaces.Services.AOP.Business;
using RG.Application.Interfaces.Services.Embro.Setups;
using RG.Application.Interfaces.Services.MaterialsManagement.Business;
using RG.Application.Interfaces.Services.MaterialsManagement.Setups;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Setup;
using RG.Application.Interfaces.Services.UserAuthGBS.API.UserInfos;
using RG.Application.ViewModel.MaterialsManagement.Business.GatePass;
using RG.DBEntities.MaterialsManagement.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.MaterialsManagement.Business
{
    public class GatePassChallanService : IGatePassChallanService
    {
        private readonly IIC_GatepassMasterRepository iC_GatepassMasterRepository;
        private readonly IIC_UnitSetupRepository iC_UnitSetupRepository;
        private readonly IIC_DepartmentService iC_DepartmentService;
        private readonly IUser_SetupRepository user_SetupRepository;
        private readonly IStyleService styleService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISupplierSetupService supplierSetupService;
        private readonly IIC_ReturnableItemCategoryService iC_ReturnableItemCategoryService;
        private readonly ITbl_Issuance_MasterRepository tbl_Issuance_MasterRepository;
        private readonly ICountry_Assorment_SetupService _country_Assorment_SetupService;
        private readonly IUserAccessInfoService _userAccessInfoService;
        private readonly Itbl_challan_masterService _tbl_Challan_MasterService;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IViw_SupplierRepository _viw_SupplierRepository;
        private readonly IStyleRepository _styleRepository;

        public GatePassChallanService(IIC_GatepassMasterRepository _iC_GatepassMasterRepository,
            IIC_UnitSetupRepository _iC_UnitSetupRepository,
            IIC_DepartmentService _iC_DepartmentService,
            IUser_SetupRepository _user_SetupRepository,
            IStyleService _styleService,
            UserManager<ApplicationUser> _userManager
            , ISupplierSetupService _supplierSetupService
            , IIC_ReturnableItemCategoryService iC_ReturnableItemCategoryService
            , ITbl_Issuance_MasterRepository _tbl_Issuance_MasterRepository
            , ICountry_Assorment_SetupService country_Assorment_SetupService
            , IUserAccessInfoService userAccessInfoService
            , Itbl_challan_masterService tbl_Challan_MasterService
            , ICompanyInfoRepository companyInfoRepository
            , IViw_SupplierRepository viw_SupplierRepository
            , IStyleRepository styleRepository)
        {
            iC_GatepassMasterRepository = _iC_GatepassMasterRepository;
            iC_UnitSetupRepository = _iC_UnitSetupRepository;
            iC_DepartmentService = _iC_DepartmentService;
            user_SetupRepository = _user_SetupRepository;
            styleService = _styleService;
            userManager = _userManager;
            supplierSetupService = _supplierSetupService;
            this.iC_ReturnableItemCategoryService = iC_ReturnableItemCategoryService;
            tbl_Issuance_MasterRepository = _tbl_Issuance_MasterRepository;
            _country_Assorment_SetupService = country_Assorment_SetupService;
            _userAccessInfoService = userAccessInfoService;
            _tbl_Challan_MasterService = tbl_Challan_MasterService;
            _companyInfoRepository = companyInfoRepository;
            _viw_SupplierRepository = viw_SupplierRepository;
            _styleRepository = styleRepository;
        }
        public async Task<GatePassChallanMasterVM> GetGatePassChallanRecord(int gatePassID, CancellationToken cancellationToken)
        {
            var challanMaster = new GatePassChallanMasterVM();
            var masterObj = await iC_GatepassMasterRepository.GetIC_GatepassMasterDetailInfoByID(gatePassID, cancellationToken);

            var company = await _companyInfoRepository.GetByIdAsync(Convert.ToDecimal(masterObj.CompanyID));


            challanMaster.CategoryID = masterObj.CategoryID.Value;
            challanMaster.Serial = masterObj.Serial;
            challanMaster.VehicleNo = masterObj.VehicleNo;
            challanMaster.DateTimeStamp = string.Format("{0:G}", masterObj.DateTimeStamp.Value);
            challanMaster.CompanyName = company.Companyname;//masterObj.CompanyID == 183 ? "Robintex (Bangladesh) Limited" : "Comptex Bangladesh Limited";
            challanMaster.CompanyAddress = company.Address;
            challanMaster.GatePassID = masterObj.ID;
            challanMaster.IsApproved = masterObj.isApproved.Value;
            challanMaster.ApprovedBy = masterObj.ApprovedBy;
            challanMaster.IsApprovedByAccounts = masterObj.IsApprovedByAccounts;
            challanMaster.AccountsApprovedBy = masterObj.AccountsApprovedBy;
            challanMaster.isMarkedOut = masterObj.isMarkedOut;
            challanMaster.PreparedBy = masterObj.CreatedBy;
            if (masterObj.CreatedBy > 0)
            {
                //var obj = await user_SetupRepository.GetUserSetupDetails((int)masterObj.CreatedBy, cancellationToken);
                //challanMaster.PreparedByUser = obj.UserName;
                var obj = await _userAccessInfoService.GetUserInfo(masterObj.CreatedBy, 0);
                challanMaster.PreparedByUser = obj != null ? obj.EmployeeName : "";
            }
            if (masterObj.ApprovedBy > 0)
            {
                //var obj = await user_SetupRepository.GetUserSetupDetails((int)masterObj.ApprovedBy.Value, cancellationToken);
                var obj = await _userAccessInfoService.GetUserInfo(0, (int)masterObj.ApprovedBy.Value);
                challanMaster.ApprovedUser = obj != null ? obj.EmployeeName : "";
            }
            if (masterObj.AccountsApprovedBy != null && masterObj.AccountsApprovedBy > 0)
            {
                //var obj = await userManager.Users.Where(x => x.SourceUserID == (int)masterObj.AccountsApprovedBy).FirstAsync();//await user_SetupRepository.GetUserSetupDetails((int)masterObj.AccountsApprovedBy.Value, cancellationToken);
                var obj = await _userAccessInfoService.GetUserInfo((int)masterObj.AccountsApprovedBy, 0);
                challanMaster.AccountsApprovedUser = obj != null ? obj.EmployeeName : "";
            }

            if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.SampleGmts)
            {
                challanMaster.CategoryName = IC_DocumentCategoriesCC.SampleGmts;
                if (masterObj.IC_SampleGatePassMaster == null)
                {
                    challanMaster.DepartmentID = 0;
                }
                else
                {
                    challanMaster.DepartmentID = masterObj.IC_SampleGatePassMaster.DepartmentID;
                }

                challanMaster.CustomerName = masterObj.IC_SampleGatePassMaster.CustomerName;
                if (masterObj.IC_SampleGatePassMaster.OrderID != null && masterObj.IC_SampleGatePassMaster.OrderID > 0)
                {
                    challanMaster.OrderReferenceNo = (await styleService.GetStyleByID(masterObj.IC_SampleGatePassMaster.OrderID.Value, cancellationToken)).OrderNo;
                }
                else
                {
                    challanMaster.OrderReferenceNo = masterObj.IC_SampleGatePassMaster.ReferenceNo;
                }

                challanMaster.CarrierName = masterObj.IC_SampleGatePassMaster.CarrierName;
                challanMaster.WeightSlipNo = masterObj.IC_SampleGatePassMaster.WeightSlipNo;
                challanMaster.GatePassChallanDetails = await GetSampleChallanMasterDetails(masterObj.IC_SampleGatePassMaster.IC_SampleGatePassDetail, cancellationToken);
            }
            else if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.LocalSales)
            {
                challanMaster.PaymentMode = masterObj.IC_LocalSalesGatePassMaster.PaymentMode.Value;
                challanMaster.CategoryName = IC_DocumentCategoriesCC.LocalSales;
                challanMaster.DepartmentID = (int)masterObj.IC_LocalSalesGatePassMaster.DepartmentID;
                challanMaster.GatePassChallanDetails = await GetLocalSalesChallanMasterDetails(masterObj.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail, cancellationToken);
                var challanList = challanMaster.GatePassChallanDetails.Select(x => x.RefNo).Distinct();
                challanMaster.CustomerChallanNo = string.Join(",", challanList);
                var firstDetail = masterObj.IC_LocalSalesGatePassMaster.IC_LocalSalesGatePassDetail.FirstOrDefault();
                long issuanceDetailID = 0;
                if (firstDetail != null && firstDetail.ProcessID.Value != 6)
                {
                    issuanceDetailID = firstDetail.IssuanceDetailID.Value;
                    var customerInfo = await _tbl_Challan_MasterService.GetChallanCustomerInfo(issuanceDetailID, cancellationToken);
                    challanMaster.CustomerName = customerInfo.CustomerName;
                    challanMaster.CustomerAddress = customerInfo.CustomerAddress;
                }
                else if (firstDetail.ProcessID.Value == 6)
                {
                    var supplierInfo = await _viw_SupplierRepository
                        .FindAsync(b => b.SupplierID == (int)masterObj.IC_LocalSalesGatePassMaster.CustomerID, cancellationToken);
                    //   var orderInfo = _styleRepository.FindAsync(b=>b.ID==)
                    if (supplierInfo != null)
                    {
                        challanMaster.CustomerName = supplierInfo.CompanyName;
                        challanMaster.CustomerAddress = supplierInfo.Address;
                    }
                    challanMaster.CustomerChallanNo = firstDetail.OrderName;


                }

            }
            else if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.NonReturnable)
            {
                challanMaster.CategoryName = IC_DocumentCategoriesCC.NonReturnable;
                challanMaster.DepartmentID = (int)masterObj.IC_NonReturnableGatePassMaster.DepartmentID;
                challanMaster.CustomerName = masterObj.IC_NonReturnableGatePassMaster.IssuedToID;
                challanMaster.Purpose = masterObj.IC_NonReturnableGatePassMaster.Purpose;
                challanMaster.GatePassChallanDetails = await GetNonReturnableChallanMasterDetails(masterObj.IC_NonReturnableGatePassMaster.IC_NonReturnableGatePassDetail, cancellationToken);



            }
            else if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.Returnable)
            {
                var dbVendor = await supplierSetupService.GetSupplierInfo(masterObj.IC_ReturnableGatePassMaster.VendorID);
                if (dbVendor != null)
                {
                    challanMaster.VendorSupplier = dbVendor.CompanyName;
                }
                challanMaster.CategoryName = IC_DocumentCategoriesCC.Returnable;
                challanMaster.CustomerName = masterObj.IC_ReturnableGatePassMaster.IssuedTo;
                challanMaster.Representative = masterObj.IC_ReturnableGatePassMaster.Representative;
                challanMaster.RepresentativeContact = masterObj.IC_ReturnableGatePassMaster.RepresentativeContact;
                challanMaster.Description = masterObj.IC_ReturnableGatePassMaster.JobDesc;

                challanMaster.GatePassChallanDetails = await GetReturnableChallanMasterDetails(masterObj.IC_ReturnableGatePassMaster.IC_ReturnableGatePassDetail, cancellationToken);
            }
            else if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.ExportSales)
            {

                challanMaster.CategoryName = IC_DocumentCategoriesCC.ExportSales;
                challanMaster.CustomerName = masterObj.IC_ExportSalesGatePassMaster.CustomerId;
                challanMaster.Purpose = masterObj.IC_ExportSalesGatePassMaster.Purpose;
                challanMaster.VehicleRef = masterObj.IC_ExportSalesGatePassMaster.VehicleRef;
                challanMaster.Description = masterObj.IC_ExportSalesGatePassMaster.Description;
                challanMaster.DriverName = masterObj.IC_ExportSalesGatePassMaster.DriverName;
                challanMaster.MobileNo = masterObj.IC_ExportSalesGatePassMaster.MobileNo;
                challanMaster.TransportServiceName = masterObj.IC_ExportSalesGatePassMaster.TransportServiceName;
                challanMaster.Time = string.Format("{0:g}", masterObj.DateTimeStamp.Value);
                challanMaster.GatePassChallanDetails = await GetExportSalesChallanMasterDetails(masterObj.IC_ExportSalesGatePassMaster.IC_ExportSalesGatePassDetail, cancellationToken);
            }
            else if (masterObj.CategoryID == IC_DocumentCategoriesIDCC.ScrapSales)
            {
                challanMaster.CategoryName = IC_DocumentCategoriesCC.ScrapSales;
                challanMaster.CustomerID = masterObj.IC_ScrapSalesGatePassMaster.ScrapCustomerID.ToString();
                challanMaster.CustomerName = (await supplierSetupService.GetSupplierInfo((int)masterObj.IC_ScrapSalesGatePassMaster.ScrapCustomerID)).CompanyName;
                challanMaster.DepartmentID = masterObj.IC_ScrapSalesGatePassMaster.DepartmentId;
                challanMaster.PaymentMode = masterObj.IC_ScrapSalesGatePassMaster.PaymentMode.Value;
                //challanMaster.VehicleRef = masterObj.IC_ScrapSalesGatePassMaster.VehicleDriverMobileNo;
                challanMaster.Description = masterObj.IC_ScrapSalesGatePassMaster.Description;
                //challanMaster.DriverName = masterObj.IC_ExportSalesGatePassMaster.DriverName;
                challanMaster.MobileNo = masterObj.IC_ScrapSalesGatePassMaster.VehicleDriverMobileNo;
                challanMaster.GatePassChallanDetails = await GetScrapSalesChallanMasterDetails(masterObj.IC_ScrapSalesGatePassMaster.IC_ScrapSalesGatePassDetail, cancellationToken);
            }

            if (challanMaster.DepartmentID != null)
                challanMaster.DepartmentName = (await iC_DepartmentService.DDLGetDepartmentList(cancellationToken, challanMaster.DepartmentID.Value)).First().Text;

            return challanMaster;
        }

        private async Task<List<GatePassChallanDetailsVM>> GetScrapSalesChallanMasterDetails(List<IC_ScrapSalesGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();
            foreach (var detail in itemDetail)
            {
                var challanDetails = new GatePassChallanDetailsVM();
                var unitInfo = await iC_UnitSetupRepository.GetByIdAsync(detail.UnitID, cancellationToken);
                //var unitName = unitlist.Where(b => b.Value == detail.UnitID.ToString()).First().Text;
                challanDetails.ID = (int)detail.ID;
                challanDetails.ItemName = detail.ItemName;
                challanDetails.Remarks = detail.Remarks;
                challanDetails.Quantity = (decimal)detail.Quantity;
                challanDetails.UnitID = detail.UnitID;
                challanDetails.UnitName = unitInfo.Name;
                challanDetails.DecimalPoint = unitInfo.DecimalPoint ?? 2;
                challanDetailsList.Add(challanDetails);
            }
            return challanDetailsList;
        }

        private async Task<List<GatePassChallanDetailsVM>> GetSampleChallanMasterDetails(List<IC_SampleGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();
            foreach (var detail in itemDetail)
            {
                var challanDetails = new GatePassChallanDetailsVM();
                var unitInfo = await iC_UnitSetupRepository.GetByIdAsync(detail.UnitID, cancellationToken);
                //var unitName = unitlist.Where(b => b.Value == detail.UnitID.ToString()).First().Text;
                challanDetails.ID = (int)detail.ID;
                challanDetails.ItemName = detail.ItemName;
                challanDetails.Remarks = detail.Remarks;
                challanDetails.Quantity = (decimal)detail.Quantity;
                challanDetails.UnitID = detail.UnitID;
                challanDetails.UnitName = unitInfo.Name;
                challanDetails.DecimalPoint = unitInfo.DecimalPoint ?? 2;
                challanDetailsList.Add(challanDetails);
            }
            return challanDetailsList;
        }

        private async Task<List<GatePassChallanDetailsVM>> GetReturnableChallanMasterDetails(List<IC_ReturnableGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();
            foreach (var detail in itemDetail)
            {
                var challanDetails = new GatePassChallanDetailsVM();
                var unitIfno = await iC_UnitSetupRepository.GetByIdAsync(detail.UnitID, cancellationToken);
                var returnableItemCategoryID = detail.ReturnableItemCategoryID == 0 ? 2 : detail.ReturnableItemCategoryID;
                //var unitName = unitlist.Where(b => b.Value == detail.UnitID.ToString()).First().Text;
                challanDetails.ID = (int)detail.ID;
                challanDetails.RequisitionID = detail.RequisitionID;

                challanDetails.ReturnableItemCategory = (await iC_ReturnableItemCategoryService.DDLIC_ReturnableItemCategory()).ToList().Where(x => x.Value == returnableItemCategoryID.ToString()).First().Text;
                challanDetails.ItemName = detail.ItemName;
                challanDetails.QuantityOrGrossWeight = (decimal)detail.Quantity + (decimal)detail.GrossWeight.Value;
                challanDetails.RecieveQuantity = detail.RecieveQuantity == null ? 0 : detail.RecieveQuantity;
                challanDetails.WastageQuantity = detail.WastageQuantity == null ? 0 : detail.WastageQuantity;

                challanDetails.GrossWeight = detail.GrossWeight.Value;
                challanDetails.Remarks = detail.Remarks;
                challanDetails.ExpectedReturnDate = detail.ExpectedReturnDate.ToString("dd-MMM-yyyy");
                challanDetails.Quantity = (decimal)detail.Quantity;
                challanDetails.CartonQty = detail.RecieveQuantity == null ? 0 : (long)detail.RecieveQuantity.Value;
                challanDetails.UnitID = detail.UnitID;
                challanDetails.UnitName = unitIfno.Name;
                challanDetails.DecimalPoint = unitIfno.DecimalPoint ?? 2;

                challanDetailsList.Add(challanDetails);
            }
            return challanDetailsList;
        }
        private async Task<List<GatePassChallanDetailsVM>> GetNonReturnableChallanMasterDetails(List<IC_NonReturnableGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();
            foreach (var detail in itemDetail)
            {
                var challanDetails = new GatePassChallanDetailsVM();
                var unitInfo = await iC_UnitSetupRepository.GetByIdAsync(detail.UnitID, cancellationToken);
                //var unitName = unitlist.Where(b => b. == detail.UnitID.ToString()).First().Text;
                challanDetails.ID = (int)detail.ID;
                challanDetails.ItemName = detail.ItemName;
                challanDetails.GrossWeight = (decimal)detail.GrossWeight;
                challanDetails.Remarks = detail.Remarks;
                challanDetails.Quantity = (decimal)detail.Quantity;
                challanDetails.UnitName = unitInfo.Name;
                challanDetails.DecimalPoint = unitInfo.DecimalPoint ?? 2;
                challanDetailsList.Add(challanDetails);
            }
            return challanDetailsList;
        }
        private async Task<List<GatePassChallanDetailsVM>> GetExportSalesChallanMasterDetails(List<IC_ExportSalesGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();
            var countries = await _country_Assorment_SetupService.DDLGetCountryList(cancellationToken);
            foreach (var exportSales in itemDetail)
            {
                var challanDetails = new GatePassChallanDetailsVM();
                var unitInfo = await iC_UnitSetupRepository.GetByIdAsync(exportSales.UnitId, cancellationToken);
                //var unitName = unitlist.Where(b => b.Value == exportSales.UnitId.ToString()).First().Text;

                var countryName = "";
                if (exportSales.CountryID.HasValue && exportSales.CountryID.Value > 0)
                {
                    countryName = countries.Where(x => Convert.ToInt32(x.Value) == exportSales.CountryID).First().Text;
                }

                var orderNo = "";
                if (exportSales.OrderID != null && exportSales.OrderID > 0)
                {
                    var style = await styleService.GetStyleByID(exportSales.OrderID.Value, cancellationToken);
                    orderNo = style.OrderNo;
                }
                challanDetails.ID = exportSales.Id;
                challanDetails.ItemName = exportSales.ItemName;
                challanDetails.InvoiceNumber = exportSales.InvoiceNumber;
                challanDetails.ContainerNo = exportSales.ContainerNo;
                challanDetails.ContainerSize = exportSales.ContainerSize;
                challanDetails.BuyerName = exportSales.BuyerName;
                challanDetails.ClearingAgent = exportSales.ClearingAgent;
                challanDetails.SealNo = exportSales.SealNo;
                challanDetails.ShippingLine = exportSales.ShippingLine;
                challanDetails.Remarks = exportSales.Remarks;
                challanDetails.Quantity = exportSales.Quantity.Value;
                challanDetails.CartonQty = exportSales.CartonQty.Value;
                challanDetails.UnitName = unitInfo.Name;
                challanDetails.DecimalPoint = unitInfo.DecimalPoint ?? 2;
                challanDetails.CountryName = countryName;
                challanDetails.OrderNo = orderNo;

                challanDetailsList.Add(challanDetails);
            }
            return challanDetailsList;
        }

        private async Task<List<GatePassChallanDetailsVM>> GetLocalSalesChallanMasterDetails(List<IC_LocalSalesGatePassDetail> itemDetail, CancellationToken cancellationToken)
        {
            var challanDetailsList = new List<GatePassChallanDetailsVM>();

            if (itemDetail.Count > 0)
            {
                foreach (var detail in itemDetail)
                {
                    var challanDetails = new GatePassChallanDetailsVM();
                    var paymentTerm = "";
                    if (detail.ProcessID != 6)
                    {
                        var issueDetailInfo = await tbl_Issuance_MasterRepository.GetIssuancePaymentInfo(detail.IssuanceDetailID.Value);
                        paymentTerm = issueDetailInfo.PaymentTermFull;
                        challanDetails.IsCalculationWithGray = issueDetailInfo.IsCalculationWithGray;
                    }

                    var unitInfo = await iC_UnitSetupRepository.GetByIdAsync(detail.UnitID, cancellationToken);
                    //var unitName = unitlist.Where(b => b.Value == detail.UnitID.ToString()).First().Text;
                    challanDetails.ID = (int)detail.ID;
                    challanDetails.ItemName = detail.ItemType;
                    challanDetails.OrderNo = detail.OrderNo;
                    challanDetails.ProcessCodeID = detail.ProcessCodeID;
                    challanDetails.ContainerSize = detail.ColorFinishCode;
                    challanDetails.GrossWeight = detail.GrossWeight.Value;
                    challanDetails.NetWeight = detail.NetWeight.Value;
                    challanDetails.Remarks = detail.Remarks;
                    challanDetails.Quantity = detail.Quantity;
                    challanDetails.CartonQty = (long)detail.Rate;
                    challanDetails.UnitName = unitInfo.Name;
                    challanDetails.DecimalPoint = unitInfo.DecimalPoint ?? 2;
                    challanDetails.PaymentTerm = paymentTerm;
                    challanDetails.RefNo = detail.RefNo;
                    challanDetails.FinishedWidth = detail.FinishedWidth;
                    challanDetails.GreigeWidth = detail.GreigeWidth;
                    challanDetails.Roll = detail.Roll;
                    challanDetails.Rate = detail.Rate == null ? 0 : detail.Rate;
                    challanDetailsList.Add(challanDetails);
                }
            }
            return challanDetailsList;
        }
    }
}
