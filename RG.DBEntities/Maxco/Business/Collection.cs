using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class Collection
    {
        public int ID { get; set; }
        public string Description { get; set; }        
        public int BuyerID { get; set; }
        public byte GenderID { get; set; }
        public DateTime CreationDate { get; set; }

        public int SeasonID { get; set; }
        public byte Status { get; set; }
        public int Year { get; set; }
        public DateTime? AssignedDate { get; set; }
        public int? FabricCategoryID { get; set; }
        public int? DivisionID { get; set; }

        public virtual Gender_Setup Gender { get; set; }
    }
}
