using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
  public  class DepriciationPolicy
    {
      [Key]
        public int PolicyID { get; set; }
        public string Description { get; set; }
    }
}
