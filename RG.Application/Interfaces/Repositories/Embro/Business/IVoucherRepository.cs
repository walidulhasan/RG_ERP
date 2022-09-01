using RG.DBEntities.Embro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Embro.Business
{
    public interface IVoucherRepository:IGenericRepository<Voucher>
    {
        Task<string> SaveYarnIssuanceVoucher(long IssuanceNo, long YKNCID, int YKNCCompanyID,int LotCompanyID,int UserBusinessID, decimal Rate,decimal Quantity,decimal Amount, DateTime? YkncDate = null);
        Task<int> GetLastVoucherSerial(int VoucherTypeId, int CompanyId, int BusinessId, DateTime VoucherDate);
    }
}
