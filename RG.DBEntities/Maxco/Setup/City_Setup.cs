using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class City_Setup
    {
        public City_Setup()
        {
            //LcMcMasterChildLmcExpirycity = new HashSet<LcMcMasterChild>();
            //LcMcMasterChildLmcIssuancecity = new HashSet<LcMcMasterChild>();
            //SampleDestination = new HashSet<SampleDestination>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public byte CountryID { get; set; }

        public virtual Country_Setup Country { get; set; }
        //public virtual ICollection<LcMcMasterChild> LcMcMasterChildLmcExpirycity { get; set; }
        //public virtual ICollection<LcMcMasterChild> LcMcMasterChildLmcIssuancecity { get; set; }
        //public virtual ICollection<SampleDestination> SampleDestination { get; set; }
    }
}
