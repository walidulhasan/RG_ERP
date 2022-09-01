using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.Setup
{
    public partial class SetupDetail
    {
        public SetupDetail()
        {
            SetupMaping = new HashSet<SetupMaping>();
        }

        public short Id { get; set; }
        public short? ParentId { get; set; }
        public string Description { get; set; }
        public string TableName { get; set; }
        public string RedirectPageName { get; set; }

        public virtual ICollection<SetupMaping> SetupMaping { get; set; }
    }
}
