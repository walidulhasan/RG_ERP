using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class QRM_UPCSpecification
    {
        public int ID { get; set; }
        public int? ObjectID { get; set; }
        public int? TrimID { get; set; }
        public long? ColorID { get; set; }
        public long? SizeID { get; set; }
        public string UPC { get; set; }
    }
}
