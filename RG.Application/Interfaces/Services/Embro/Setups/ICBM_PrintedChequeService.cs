using RG.Application.Common.Models;
using RG.Application.Contracts.Embro.Setups.CBM_PrintedCheques.Commands.DataTransferModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.Embro.Setups
{
    public interface ICBM_PrintedChequeService
    {
        Task<RResult> UpdateChequeStatus(List<UpdateChequeStatusDTM> SelectedData,bool saveChanges=true);
    }
}
