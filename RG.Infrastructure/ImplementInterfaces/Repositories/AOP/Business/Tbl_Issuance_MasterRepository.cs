using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Contracts.AOP.Business.Tbl_Issuance_Masters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.AOP.Business;
using RG.DBEntities.AOP.Business;
using RG.Infrastructure.Persistence.AOPDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.AOP.Business
{
    public class Tbl_Issuance_MasterRepository : GenericRepository<Tbl_Issuance_Master>, ITbl_Issuance_MasterRepository
    {
        private readonly AOPDBContext dbCon;
        public Tbl_Issuance_MasterRepository(AOPDBContext _dbCon) : base(_dbCon)
        {
            dbCon = _dbCon;
        }

        public async Task<List<SelectListItem>> GetDDLIssuance_DetailByMaster(long masterID, int gatePassDetailID, CancellationToken cancellationToken)
        {
            var data = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLIssuance_DetailByMaster")
                                .WithSqlParam("MasterID", masterID)
                                .WithSqlParam("GatePassDetailID", gatePassDetailID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<SelectListItem>> GetDDLIssuance_Master(int supplierID, int gatePassDetailID, string predict)
        {
            var data = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetDDLIssuanceMaster")

                    .WithSqlParam("SupplierID", supplierID)
                    .WithSqlParam("GatePassDetailID", gatePassDetailID)
                                .WithSqlParam("Predict", predict)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;

        }

        public async Task<IssuanceDetailInfoSPRM> GetIssuanceDetailInfoByID(long issue_ID, long issue_DetailsID)
        {
            var detailInfo = new IssuanceDetailInfoSPRM();
            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetIssuanceDetailInfo")
                                .WithSqlParam("issue_ID", issue_ID)
                                .WithSqlParam("issue_DetailsID", issue_DetailsID)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    detailInfo = handler.ReadToList<IssuanceDetailInfoSPRM>().FirstOrDefault();
                                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return detailInfo;
        }

        public async Task<IssuancePaymentInfoSPRM> GetIssuancePaymentInfo(long issueDetailId)
        {
            var data = new IssuancePaymentInfoSPRM();
            try
            {
                await dbCon.LoadStoredProc("sp_Issue_PaymentInfo")
                                .WithSqlParam("issueDetailId", issueDetailId)
                                .ExecuteStoredProcAsync((handler) =>
                                {
                                    data = handler.ReadToList<IssuancePaymentInfoSPRM>().FirstOrDefault();
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
