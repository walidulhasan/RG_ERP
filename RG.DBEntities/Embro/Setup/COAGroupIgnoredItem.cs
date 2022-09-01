using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Embro.Setup
{
    public class COAGroupIgnoredItem : DefaultTableProperties
    {
        public int GroupIgnoredItemID { get; set; }
        [ForeignKey("COAGroupIdentification")]
        public int GroupIdentificationID { get; set; }
        public int IdentificationID { get; set; }
        public int IgnoredItemID { get; set; }
        public virtual COAGroupIdentification COAGroupIdentification { get; set; }
    }
}
