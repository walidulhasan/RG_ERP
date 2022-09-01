using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.MaterialsManagement.Business.YarnIssuanceToKnitter.Commands.DataTransferModel
{
    public class AllocatedYarnIssueDTM
    {
        public AllocatedYarnIssueDTM()
        {
            YKNCBatch = new List<YKNCBatchDTM>();
        }
       public int ID{get;set;}
       public int GreigeAttributeInstanceID{get;set;}
       public int ContractStatus{get;set;}
       public int KnitterID{get;set;}
       public int CompanyID{get;set;}
       public int ContractName{get;set;}
       public int ProgramTypeID{get;set;}
       public int OrderID{get;set;}
       public int OrderNo{get;set;}
       public int IsClosed{get;set;}
       public int NoOfDays{get;set;}
       public int PaymentTerm{get;set;}
       public int FabricTypeID{get;set;}
       public int FabricType{get;set;}
       public int QualityID{get;set;}
       public int Quality{get;set;}
       public int GSM{get;set;}
       public int MachineType{get;set;}
       public int Width{get;set;}
       public int TotalQty{get;set;}
       public int BalanceQty{get;set;}
       public int ContractDate{get;set;}
       public int ProgramType{get;set;}
       public int ContractTypeID{get;set;}
       public int UserID{get;set;}
       public int UserName{get;set;}
       public int BusinessID{get;set;}
        public List<YKNCBatchDTM> YKNCBatch { get; set; }
    }
    public class AllocatedYarnIssueDTMValidate : AbstractValidator<AllocatedYarnIssueDTM>
    {
        public AllocatedYarnIssueDTMValidate()
        {
            RuleFor(b => b.YKNCBatch)
                .NotEmpty().WithMessage("Data required.")
                .Must(BeUniqueCompany).WithMessage("You can't issue lot from different companies");
        }

        public bool BeUniqueCompany(List<YKNCBatchDTM> dataList)
        {
            var companies = dataList.Select(s => s.CompanyID).Distinct().ToList();            
            return !(companies.Count > 1);
        }
    }
}
