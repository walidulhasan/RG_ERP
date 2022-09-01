using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Setup
{
    public class COAGroupIdentification : DefaultTableProperties
    {
        //public COAGroupIdentification()
        //{
        //    COAGroupIgnoredItem = new List<COAGroupIgnoredItem>();
        //}
        public int GroupIdentificationID { get; set; }
        [ForeignKey("COAGroup")]
        public int GroupID { get; set; }
        public int IdentificationID { get; set; }
        public virtual COAGroup COAGroup { get; set; }
        //public List<COAGroupIgnoredItem> COAGroupIgnoredItem { get; set; }

        [NotMapped]
        public int GroupCategoryID { get; set; }
    }
}
