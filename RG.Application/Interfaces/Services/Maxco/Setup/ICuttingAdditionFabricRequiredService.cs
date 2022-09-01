using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Commands.DataTransferModel;
using RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries.RequestResponseModel;
using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Maxco.Setup
{
    public  interface ICuttingAdditionFabricRequiredService
    {
        Task<RResult> SaveAndUpdate(CuttingAdditionalFabricDTM model);
        IQueryable<CuttingAdditionFabricRM> GetCuttingAdditionFabricRequiredList(DateTime DateFrom, DateTime DateTo, int BuyerId = 0, long OrderID = 0);
        Task<RResult> RemoveCuttingAdditionFabricRequired(int ID, bool saveChange);
    }
}
