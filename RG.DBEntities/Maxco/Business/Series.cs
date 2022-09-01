using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class Series
    {
        public Series()
        {
            SeriesColors = new HashSet<SeriesColors>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public int CollectionID { get; set; }
        public int BasisID { get; set; }
        public int Status { get; set; }
        public DateTime CreationDate { get; set; }
        public int? GarmentTypeID { get; set; }

        public virtual SeriesBasis_Setup Basis { get; set; }
        public virtual GarmentType_Setup GarmentType { get; set; }
        public virtual ICollection<SeriesColors> SeriesColors { get; set; }
    }
}
