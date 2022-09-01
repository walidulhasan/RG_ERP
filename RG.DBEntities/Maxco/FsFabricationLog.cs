using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class FsFabricationLog
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public int StyleId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
