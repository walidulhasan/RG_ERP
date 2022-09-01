using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public class FS_ColorSet
    {
        public long ID { get; set; }
        [ForeignKey("FS_RequirementSheet_Master")]
        public int ReqID { get; set; }
        public long ColorSetID { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string HTMLcode { get; set; }
        public string VariationColor { get; set; }
        public string VariationColorHTMLcode { get; set; }
        public ICollection<FS_SizeSet> FS_SizeSet { get; set; }
        public virtual FS_RequirementSheet_Master FS_RequirementSheet_Master { get; set; }
    }
}
