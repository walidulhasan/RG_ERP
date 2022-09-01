﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonTemporaryReceivingDetail
    {
        [Key]
        public long Trdid { get; set; }
        public double Quantity { get; set; }
        public int Trid { get; set; }
        public int StoreId { get; set; }
        public int LocationId { get; set; }
        public double ContractBalance { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ContractDetId { get; set; }
        public double Rate { get; set; }
    }
}
