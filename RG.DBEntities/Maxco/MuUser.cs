using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class MuUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public string UserName { get; set; }
        public string LoginId { get; set; }
        public string PinCode { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    }
}
