using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class KRS_DETAIL
    {
        public KRS_DETAIL()
        {
            KRS_YARN_DETAILS = new HashSet<KRS_YARN_DETAILS>();
            KRS_STYLE_INFO = new HashSet<KRS_STYLE_INFO>();
            KRS_Colors = new HashSet<KRS_Colors>();
            KRS_Sizes = new HashSet<KRS_Sizes>();
        }
        public int ID { get; set; }
        [ForeignKey("KRS_MASTER")]
        public int KRS_MID { get; set; }
        public int FABID { get; set; }
        public int TYPEID { get; set; }
        public int QUALITYID { get; set; }
        public string FAB_COMPOSITION { get; set; }
        public int GSM { get; set; }
        public int GAUGE { get; set; }
        public double FINISHED_WIDTH { get; set; }
        public int ISSPANDEX { get; set; }
        public int? DYEINGID { get; set; }
        public int? KnitType { get; set; }
        public decimal? WSTG { get; set; }
        public string WSTGD { get; set; }
        public int? DyLevel { get; set; }
        public virtual KRS_MASTER KRS_MASTER { get; set; }
        public virtual ICollection<KRS_YARN_DETAILS> KRS_YARN_DETAILS { get; set; }
        public virtual ICollection<KRS_STYLE_INFO> KRS_STYLE_INFO { get; set; }
        public virtual ICollection<KRS_Colors> KRS_Colors { get; set; }
        public virtual ICollection<KRS_Sizes> KRS_Sizes { get; set; }
    }
}
