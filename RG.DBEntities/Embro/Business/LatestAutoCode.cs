using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Business
{
    public class LatestAutoCode
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public int? GeneratedCompanyId { get; set; }
        public int? GeneratedBusinessID { get; set; }
        public string PrefixCode { get; set; }
        public int Code { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
