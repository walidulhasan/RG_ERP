using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco
{
    public partial class GwmachineOperations
    {
      //  public int Id { get; set; }
        [Key]
        public long GwmachineOperationId { get; set; }
        public string GwmachineOperationName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
