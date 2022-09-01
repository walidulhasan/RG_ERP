using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Embro.Setup
{
   public class DepriciationMethod
    {
        public int ID { get; set; }
        public int MethodID { get; set; }
        public string MethodName { get; set; }
        public int? MethodType { get; set; }
    }
}
