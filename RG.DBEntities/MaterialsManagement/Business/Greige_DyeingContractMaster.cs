using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class Greige_DyeingContractMaster
    {
        public Greige_DyeingContractMaster()
        {
            Greige_DyeingContractDetail = new HashSet<Greige_DyeingContractDetail>();
            //Greige_DyeingContractDeliverySchedule = new HashSet<Greige_DyeingContractDeliverySchedule>();
        }

        public int ID { get; set; }
        public string DyeingContractNo { get; set; }
        public int? SigningAuthorityID { get; set; }
        public int? DyerID { get; set; }
        public string SpecialComments { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Status { get; set; }
        public int? UserID { get; set; }
        public int? DeliveryDateSelection { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentTerm { get; set; }
        public int? PaymentTermDays { get; set; }
        public string PaymentSubTerm { get; set; }
        public int? DyeingSourceID { get; set; }

        public virtual ICollection<Greige_DyeingContractDetail> Greige_DyeingContractDetail { get; set; }
        //public virtual ICollection<Greige_DyeingContractDeliverySchedule> Greige_DyeingContractDeliverySchedule { get; set; }
    }
}
