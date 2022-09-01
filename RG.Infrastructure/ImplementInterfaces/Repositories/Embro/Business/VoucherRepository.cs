using RG.Application.Common.CommonInterfaces;
using RG.Application.Interfaces.Repositories.Embro.Business;
using RG.DBEntities.Embro.Business;
using RG.Infrastructure.Persistence.EmbroDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Embro.Business
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private readonly EmbroDBContext _dbCon;
        private readonly ICurrentUserService _currentUserService;

        public VoucherRepository(EmbroDBContext dbcon, ICurrentUserService currentUserService) : base(dbcon)
        {
            _dbCon = dbcon;
            _currentUserService = currentUserService;
        }

        public async Task<string> SaveYarnIssuanceVoucher(long IssuanceNo, long YKNCID, int YKNCCompanyID, int LotCompanyID, int UserBusinessID, decimal Rate, decimal Quantity, decimal Amount, DateTime? YkncDate = null)
        {

            string VoucherNumber = ""; string LoanVoucherNumber = ""; string DebitVoucherNumber = "";

            int BusinessID = 0;
            Voucher voucher = new Voucher();
            Voucherdetail debit = new Voucherdetail();
            Voucherdetail credit = new Voucherdetail();


            if (YKNCCompanyID == 183)
            {
                //Debit
                debit.AccountID = 24478;
                debit.Costcenter = 21487;
                debit.Activity = 21504;
                debit.LocationID = 21484;
                debit.Amount = Amount;
                debit.Vindex = 1;
                debit.Status = "1";
                //Credit
                credit.AccountID = 1888;
                credit.Costcenter = 21487;
                credit.Activity = 21504;
                credit.LocationID = 21484;
                credit.Amount = Amount * -1;
                credit.Vindex = 101;
                credit.Status = "1";
                BusinessID = 6;
            }
            if (YKNCCompanyID == 20183)
            {
                //Debit
                debit.AccountID = 24483;
                debit.Costcenter = 21496;
                debit.Activity = 21547;
                debit.LocationID = 21486;
                debit.Amount = Amount;
                debit.Vindex = 1;
                debit.Status = "1";
                //Credit
                credit.AccountID = 21178;
                debit.Costcenter = 21496;
                debit.Activity = 21547;
                debit.LocationID = 21486;
                debit.Amount = Amount * -1;
                debit.Vindex = 1;
                debit.Status = "1";

                BusinessID = 20006;
            }
            if (YKNCCompanyID == 3684)
            {
                //Debit
                debit.AccountID = 29518;
                debit.Costcenter = 24711;
                debit.Activity = 29039;
                debit.LocationID = 21485;
                debit.Amount = Amount;
                debit.Vindex = 1;
                debit.Status = "1";
                //Credit
                credit.AccountID = 23947;
                credit.Costcenter = 24711;
                credit.Activity = 29039;
                credit.LocationID = 21485;
                credit.Amount = Amount * -1;
                credit.Vindex = 101;
                credit.Status = "1";

                BusinessID = 3507;
            }

            voucher.VoucherType = 12;
            var lastVoucherNumber = await GetLastVoucherSerial(voucher.VoucherType.Value, YKNCCompanyID, BusinessID, DateTime.Now);
            VoucherNumber = $"STV\\YN\\{(lastVoucherNumber + 1).ToString("d6")}";
            voucher.VoucherNumber = VoucherNumber;//  $"STV\\YN\\{lastVoucherNumber + 1}";
            voucher.VDate = DateTime.Now.Date;
            voucher.CompanyId = YKNCCompanyID;
            voucher.BusinessId = BusinessID;
            voucher.PreparedBy = _currentUserService.UserID;

            voucher.IndividualVoucherId = lastVoucherNumber + 1;
            voucher.VoucherDescription = $"{YKNCID}";

            voucher.PrepareDate = DateTime.Now;
            voucher.SystemVoucher = 1;
            voucher.NoOfDays = 120;
            voucher.PaymentTerm = "L/C";
            voucher.RDate = DateTime.Now;
            ///Voucher Detail
            voucher.Voucherdetail.Add(debit);
            voucher.Voucherdetail.Add(credit);

            //Voucher General

            voucher.VoucherGeneralInfo.Add(new VoucherGeneralInfo()
            {
                AccountID = debit.AccountID,
                Description = voucher.VoucherDescription,
                Billno = "0",
                RefNo = $"{IssuanceNo}",
                discount = 0,
                InTax = 0,
                Gross = debit.Amount,
                Net = debit.Amount,
                Comments = "Yarn Issue",
                Currency = "15",
                ConversionRate = 1,
                SupplierDONumber = "0",
                PODate = YkncDate ?? DateTime.Now,
                GRNDate = YkncDate ?? DateTime.Now,
                Vindex = 1,
                ExciseDuty = 0
            });
            _dbCon.Voucher.Add(voucher);
            await _dbCon.SaveChangesAsync();


            if (YKNCCompanyID != LotCompanyID)
            {
                Voucher loanvoucher = new Voucher();
                Voucher Debit_voucher = new Voucher();
                int LoanDebitID = 0; int LoanCostCenter = 0; int LoanActivity = 0; int LoanCreditID = 0; string LoanDescription = ""; int LoanLocation = 0; int LoanBusinessID = 0;
                int Debit_DebitID = 0; int Debit_CostCenter = 0; int Debit_Activity = 0; int Debit_CreditID = 0; string Debit_Description = ""; int Debit_Location = 0; int Debit_BusinessID = 0;

                if (YKNCCompanyID == 183 && LotCompanyID == 20183)
                {
                    LoanDebitID = 1888;
                    LoanCostCenter = 21487;
                    LoanActivity = 21504;
                    LoanCreditID = 23635;
                    LoanDescription = "Loan From CTX";
                    LoanLocation = 21484;
                    LoanBusinessID = 6;

                    Debit_DebitID = 23638;
                    Debit_CostCenter = 21496;
                    Debit_Activity = 21547;
                    Debit_CreditID = 21178;
                    Debit_Description = "Debit To RTX";
                    Debit_Location = 21486;
                    Debit_BusinessID = 20006;
                }
                else if (YKNCCompanyID == 183 && LotCompanyID == 3684)
                {
                    LoanDebitID = 23946;
                    LoanCostCenter = 27945;
                    LoanActivity = 27946;
                    LoanCreditID = 27452;
                    LoanDescription = "Loan From RTXG";
                    LoanLocation = 23803;
                    LoanBusinessID = 6;


                    Debit_DebitID = 27747;
                    Debit_CostCenter = 29023;
                    Debit_Activity = 29024;
                    Debit_CreditID = 23947;
                    Debit_Description = "Debit To RTX";
                    Debit_Location = 21485;
                    Debit_BusinessID = 3507;
                }
                else if (YKNCCompanyID == 20183 && LotCompanyID == 183)
                {
                    LoanDebitID = 21178;
                    LoanCostCenter = 21496;
                    LoanActivity = 21547;
                    LoanCreditID = 23638;
                    LoanDescription = "Loan From RTX";
                    LoanLocation = 21486;
                    LoanBusinessID = 20006;


                    Debit_DebitID = 23635;
                    Debit_CostCenter = 21487;
                    Debit_Activity = 21504;
                    Debit_CreditID = 1888;
                    Debit_Description = "Debit To CTX";
                    Debit_Location = 21484;
                    Debit_BusinessID = 6;
                }
                else if (YKNCCompanyID == 20183 && LotCompanyID == 3684)
                {
                    LoanDebitID = 23948;
                    LoanCostCenter = 29390;
                    LoanActivity = 29391;
                    LoanCreditID = 27751;
                    LoanDescription = "Loan From RTXG";
                    LoanLocation = 21486;
                    LoanBusinessID = 20006;


                    Debit_DebitID = 27746;
                    Debit_CostCenter = 29023;
                    Debit_Activity = 29024;
                    Debit_CreditID = 23947;
                    Debit_Description = "Debit To CTX";
                    Debit_Location = 21485;
                    Debit_BusinessID = 3507;
                }

                else if (YKNCCompanyID == 3684 && LotCompanyID == 183)
                {
                    LoanDebitID = 23947;
                    LoanCostCenter = 29023;
                    LoanActivity = 29024;
                    LoanCreditID = 27747;
                    LoanDescription = "Loan From RTX";
                    LoanLocation = 21485;
                    LoanBusinessID = 3507;


                    Debit_DebitID = 27452;
                    Debit_CostCenter = 27945;
                    Debit_Activity = 27946;
                    Debit_CreditID = 23946;
                    Debit_Description = "Debit To RTXG";
                    Debit_Location = 23803;
                    Debit_BusinessID = 6;
                }
                else if (YKNCCompanyID == 3684 && LotCompanyID == 20183)
                {
                    LoanDebitID = 23947;
                    LoanCostCenter = 29023;
                    LoanActivity = 29024;
                    LoanCreditID = 27746;
                    LoanDescription = "Loan From CTX";
                    LoanLocation = 21485;
                    LoanBusinessID = 3507;


                    Debit_DebitID = 27751;
                    Debit_CostCenter = 29390;
                    Debit_Activity = 29391;
                    Debit_CreditID = 23948;
                    Debit_Description = "Debit To RTXG";
                    Debit_Location = 21486;
                    Debit_BusinessID = 20006;
                }

                //Loan Voucher
                loanvoucher.VoucherType = 34;
                var loanlastVoucherNumber = await GetLastVoucherSerial(loanvoucher.VoucherType.Value, YKNCCompanyID, LoanBusinessID, DateTime.Now);
                LoanVoucherNumber = $"ITV\\YN\\{(loanlastVoucherNumber + 1).ToString("d6")}";
                loanvoucher.VoucherNumber = LoanVoucherNumber;//  $"STV\\YN\\{lastVoucherNumber + 1}";
                loanvoucher.VDate = DateTime.Now.Date;
                loanvoucher.CompanyId = YKNCCompanyID;
                loanvoucher.BusinessId = LoanBusinessID;
                loanvoucher.PreparedBy = _currentUserService.UserID;
                loanvoucher.IndividualVoucherId = loanlastVoucherNumber + 1;
                loanvoucher.VoucherDescription = LoanDescription;
                loanvoucher.PrepareDate = DateTime.Now;
                loanvoucher.SystemVoucher = 1;
                loanvoucher.NoOfDays = 120;
                loanvoucher.PaymentTerm = "L/C";
                loanvoucher.RDate = DateTime.Now;
                ///Voucher Detail
                loanvoucher.Voucherdetail.Add(new Voucherdetail()
                {
                    AccountID = LoanDebitID,
                    Activity = LoanActivity,
                    Amount = Amount,
                    Costcenter = LoanCostCenter,
                    LocationID = LoanLocation,
                    Status = "1",
                    Vindex = 1
                });
                loanvoucher.Voucherdetail.Add(new Voucherdetail()
                {
                    AccountID = LoanCreditID,
                    Activity = Debit_Activity,
                    Amount = Amount * -1,
                    Costcenter = Debit_CostCenter,
                    LocationID = Debit_Location,
                    Status = "1",
                    Vindex = 101
                });
                loanvoucher.VoucherGeneralInfo.Add(new VoucherGeneralInfo()
                {
                    AccountID = LoanDebitID,
                    Description = LoanDescription,
                    Billno = "0",
                    RefNo = $"{IssuanceNo}",
                    discount = 0,
                    InTax = 0,
                    Gross = Amount,
                    Net = Amount,
                    Comments = $"YKNC-{YKNCID}",
                    Currency = "15",
                    ConversionRate = 1,
                    SupplierDONumber = "0",
                    PODate = YkncDate ?? DateTime.Now,
                    GRNDate = YkncDate ?? DateTime.Now,
                    Vindex = 1,
                    ExciseDuty = 0
                });
                _dbCon.Voucher.Add(loanvoucher);
                await _dbCon.SaveChangesAsync();

                ///Debit Voucher
                Debit_voucher.VoucherType = 34;
                var debitlastVoucherNumber = await GetLastVoucherSerial(Debit_voucher.VoucherType.Value, LotCompanyID, Debit_BusinessID, DateTime.Now);
                DebitVoucherNumber = $"ITV\\YN\\{(debitlastVoucherNumber + 1).ToString("d6")}";
                Debit_voucher.VoucherNumber = DebitVoucherNumber;//  $"STV\\YN\\{lastVoucherNumber + 1}";
                Debit_voucher.VDate = DateTime.Now.Date;
                Debit_voucher.CompanyId = LotCompanyID;
                Debit_voucher.BusinessId = Debit_BusinessID;
                Debit_voucher.PreparedBy = _currentUserService.UserID;

                Debit_voucher.IndividualVoucherId = debitlastVoucherNumber + 1;
                Debit_voucher.VoucherDescription = Debit_Description;

                Debit_voucher.PrepareDate = DateTime.Now;
                Debit_voucher.SystemVoucher = 1;
                Debit_voucher.NoOfDays = 120;
                Debit_voucher.PaymentTerm = "L/C";
                Debit_voucher.RDate = DateTime.Now;
                ///Voucher Detail
                Debit_voucher.Voucherdetail.Add(new Voucherdetail()
                {
                    AccountID = Debit_DebitID,
                    Activity = Debit_Activity,
                    Amount = Amount,
                    Costcenter = Debit_CostCenter,
                    LocationID = Debit_Location,
                    Status = "1",
                    Vindex = 1
                });
                Debit_voucher.Voucherdetail.Add(new Voucherdetail()
                {
                    AccountID = Debit_CreditID,
                    Activity = Debit_Activity,
                    Amount = Amount * -1,
                    Costcenter = Debit_CostCenter,
                    LocationID = Debit_Location,
                    Status = "1",
                    Vindex = 101
                });
                Debit_voucher.VoucherGeneralInfo.Add(new VoucherGeneralInfo()
                {
                    AccountID = Debit_DebitID,
                    Description = Debit_Description,
                    Billno = "0",
                    RefNo = $"{IssuanceNo}",
                    discount = 0,
                    InTax = 0,
                    Gross = Amount,
                    Net = Amount,
                    Comments = $"YKNC-{YKNCID}",
                    Currency = "15",
                    ConversionRate = 1,
                    SupplierDONumber = "0",
                    PODate = YkncDate ?? DateTime.Now,
                    GRNDate = YkncDate ?? DateTime.Now,
                    Vindex = 1,
                    ExciseDuty = 0
                });
                _dbCon.Voucher.Add(Debit_voucher);
                await _dbCon.SaveChangesAsync();
            }
            var rtnVoucherNumber = $"Issue Voucher:{VoucherNumber}";
            if (!string.IsNullOrWhiteSpace(LoanVoucherNumber))
            {
                rtnVoucherNumber = rtnVoucherNumber + $"<br/> Loan Voucher {LoanVoucherNumber}";
            }
            if (!string.IsNullOrWhiteSpace(DebitVoucherNumber))
            {
                rtnVoucherNumber = rtnVoucherNumber + $"<br/> Debit Voucher {DebitVoucherNumber}";
            }

            return rtnVoucherNumber;
        }



        public async Task<int> GetLastVoucherSerial(int VoucherTypeId, int CompanyId, int BusinessId, DateTime VoucherDate)
        {

            DbParameter outputParam = null;
            int currentYearVoucherID = 0;
            await _dbCon.LoadStoredProc("dbo.Usp_Voucher_Max_GET")
            .WithSqlParam("vtype", VoucherTypeId)
            .WithSqlParam("Company", CompanyId)
            .WithSqlParam("business", BusinessId)
            .WithSqlParam("VMonth", VoucherDate.Month)
            .WithSqlParam("VYear", VoucherDate.Year)
            .WithSqlParam("Vmax", (dbParam) =>
            {
                dbParam.Direction = System.Data.ParameterDirection.Output;
                dbParam.DbType = System.Data.DbType.Int32;
                outputParam = dbParam;
            })
            .ExecuteStoredNonQueryAsync();

            if (outputParam.Value == null)
            {
                currentYearVoucherID = 0;
            }
            else if (outputParam.Value != null)
            {
                currentYearVoucherID = (int)outputParam.Value;
            }
            return currentYearVoucherID;
        }
    }
}
