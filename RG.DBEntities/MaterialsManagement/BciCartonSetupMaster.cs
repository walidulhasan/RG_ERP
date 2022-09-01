using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class BciCartonSetupMaster
    {
        public BciCartonSetupMaster()
        {
            BciCartonSetupDetail = new HashSet<BciCartonSetupDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CartonNo { get; set; }
        public int BciFgqid { get; set; }
        public string SystemBarCode { get; set; }
        public int? BciCartonStatusId { get; set; }
        public int? OrderId { get; set; }
        public string Order { get; set; }
        public int? BciCartonTypeSetupId { get; set; }
        public int? CustomerId { get; set; }
        public int? DestinationId { get; set; }
        public int? OrderDeliveryId { get; set; }
        public long? ContainerId { get; set; }
        public long? PickListId { get; set; }
        public long? UserId { get; set; }

        public virtual BciCartonStatus BciCartonStatus { get; set; }
        public virtual BciCustomer Customer { get; set; }
        public virtual BciDestination Destination { get; set; }
        public virtual ICollection<BciCartonSetupDetail> BciCartonSetupDetail { get; set; }
    }
}
