using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.Embro.Setup
{
    public class COAGroupCategory:DefaultTableProperties
    {
        public int GroupCategoryID { get; set; }
        public string GroupCategoryName { get; set; }
        public virtual List<COAGroup> COAGroup { get; set; }
    }
}
