using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblDyeingMachine
    {
        public int Id { get; set; }
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public long? CompanyId { get; set; }
        public int? Catagory { get; set; }
    }
}
