using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.Maxco.Business
{
    public partial class KRS_SearchXML
    {
        [Key]
        public int KRSXMLID { get; set; }
        public int KRS_ID { get; set; }
        public string SearchXML { get; set; }
    }
}
