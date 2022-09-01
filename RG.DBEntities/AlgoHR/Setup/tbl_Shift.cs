using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class tbl_Shift
    {
        public int Shift_ID { get; set; }
        public string Shift_Cd { get; set; }
        public string Shift_Name { get; set; }
        public int? Shift_Company { get; set; }
        public string Shift_In { get; set; }
        public string Shift_Out { get; set; }
        public int? Shift_GraceIn { get; set; }
        public int? Shift_GraceOut { get; set; }
        public string Shift_LunchInMin { get; set; }
        public string Shift_LunchInMax { get; set; }
        public DateTime? Shift_Created { get; set; }
        public bool? Shift_Active { get; set; }
        public int? Shift_OTRange { get; set; }
        public bool? Shift_Type { get; set; }
        public bool? Shift_Night { get; set; }
        public bool? Shift_Mon { get; set; }
        public bool? Shift_Tue { get; set; }
        public bool? Shift_Wed { get; set; }
        public bool? Shift_Thu { get; set; }
        public bool? Shift_Fri { get; set; }
        public bool? Shift_Sat { get; set; }
        public bool? Shift_Sun { get; set; }
        public double? Shift_InMinMin { get; set; }
        public double? Shift_InMaxMin { get; set; }
        public double? Shift_OutMinMin { get; set; }
        public double? Shift_OutMaxMin { get; set; }
        public bool? Shift_IsCyclic { get; set; }
        public int? Shift_Sequence { get; set; }
        public string Shift_Abrivation { get; set; }
        public bool? Shift_twoDaySpan { get; set; }
        public string Shift_Bname { get; set; }
        public string Shift_Brest { get; set; }
        public string Shift_Brestday { get; set; }
    }
}
