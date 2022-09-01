using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Business
{
    public class IC_SampleGatePassMaster : DefaultTableProperties
    {
        public IC_SampleGatePassMaster()
        {
            IC_SampleGatePassDetail = new List<IC_SampleGatePassDetail>();
        }
       
        public long GatePassID { get; set; }
        public int SampleProcessTypeID { get; set; }
        public int? CustomerTypeID { get; set; }
        public long? CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? OrderID { get; set; }
        public string ReferenceNo { get; set; }
        public string CarrierName { get; set; }
        public string SampleDescription { get; set; }
        public long? IssuedBy { get; set; }

        public string WeightSlipNo { get; set; }
        public int? DepartmentID { get; set; }        
        public virtual IC_GatepassMaster IC_GatepassMaster { get; set; }
        public virtual List<IC_SampleGatePassDetail> IC_SampleGatePassDetail { get; set; }
    }
}
