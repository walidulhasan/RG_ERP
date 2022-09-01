using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
    public class FSG_Setup_Master
    {
        [Key, Column(Order = 0)]
        public int FSGID { get; set; }
        [Key, Column(Order = 1)]
        public string FSGName { get; set; }
        public string FSGHeading { get; set; }
        public int CompanyID { get; set; }
    }
}
