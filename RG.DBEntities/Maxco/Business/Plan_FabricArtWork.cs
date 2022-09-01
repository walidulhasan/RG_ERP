using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_FabricArtWork:DefaultTableProperties
    {
        public int FabricArtWorkID { get; set; }
        [ForeignKey("Plan_StyleFabrics")]
        public int StyleFabricsID { get; set; }
        public DateTime ArtWorkDate { get; set; }
        [NotMapped]
        public string ArtWorkDateMsg { get { return ArtWorkDate.ToString("dd-MMM-yyyy"); } }
        public int ArtWorkID { get; set; }
        public decimal ArtWorkQuantity { get; set; } 
        
        public virtual Plan_StyleFabrics Plan_StyleFabrics { get; set; }
    }
}
