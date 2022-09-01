using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class ChainMachineDetailSetup
    {
        public int Id { get; set; }
        public int ChainMachineTypeId { get; set; }
        public string MachineCode { get; set; }
        public string MachineNo { get; set; }
        public short BrandId { get; set; }
        public string ModelNo { get; set; }
        public int CurrentStorageLocation { get; set; }
        public int Status { get; set; }
        public string Famcode { get; set; }
        public string Origin { get; set; }
    }
}
