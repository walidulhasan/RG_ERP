using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class DomainServer
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string ServerName { get; set; }
    }
}
