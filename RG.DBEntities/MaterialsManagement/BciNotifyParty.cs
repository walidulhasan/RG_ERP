using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciNotifyParty
    {
        public int Id { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string TelePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
