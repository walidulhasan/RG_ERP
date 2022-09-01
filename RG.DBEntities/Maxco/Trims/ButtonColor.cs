using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;
namespace RG.DBEntities.Maxco.Trims
{
    public partial class ButtonColor
    {
       public int ID { get; set; }
        /// <summary>
        /// Fabric Specification Color ID
        /// </summary>
        public long ColorSetID { get; set; }
        public string TrimColor { get; set; }
        public int? MatchID { get; set; }
       /// <summary>
       /// Button Specification ID
       /// </summary>
       [ForeignKey("ButtonSpecification")]
        public long ObjectID { get; set; }

        public virtual FabricSpecificationColor ColorSet { get; set; }
        public virtual ColorMatching_Setup Match { get; set; }
        public virtual ButtonSpecification ButtonSpecification { get; set; }
    }
}
