using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class LdRcpMaster
    {
        public int Id { get; set; }
        public int Rcpid { get; set; }
        public int Ldid { get; set; }
        public string Rcpname { get; set; }
        public int Status { get; set; }
        public int Usrid { get; set; }
        public DateTime SubmitDate { get; set; }
        public string Comments { get; set; }
        public int? ApproveUser { get; set; }
        public DateTime? ApproveDate { get; set; }
        public int? LabLocation { get; set; }
        public int? Shade { get; set; }
        public int? Process { get; set; }
    }
}
