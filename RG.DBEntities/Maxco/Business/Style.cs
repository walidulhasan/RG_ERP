using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
   public class Style
    {
        public Style()
        {
            CollectionModel_PriceList = new HashSet<CollectionModel_PriceList>();
            //SampleAssortment = new HashSet<SampleAssortment>();
            //SampleBom = new HashSet<SampleBom>();
            //SampleDestination = new HashSet<SampleDestination>();
            //StyleImage = new HashSet<StyleImage>();
            SelectedElement = new HashSet<SelectedElement>();

        }

        public long ID { get; set; }
        public string Description { get; set; }
        public int? GarmentID { get; set; }
        public int? Status { get; set; }
        public DateTime? SamplingDate { get; set; }
        public int? CapturingStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? SeriesID { get; set; }
        public long? ParentStyleID { get; set; }
        public int? FabricCategoryID { get; set; }
        public int? ParentID { get; set; }
        public string OrderNo { get; set; }
        public int? CollectionID { get; set; }
        public int? UserID { get; set; }
        public int? ProcurementStatus { get; set; }
        public int IsLocked { get; set; }
        public int IsDummy { get; set; }
        public bool? GrossStatus { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public byte[] FrontImage { get; set; }
        public byte[] BackImage { get; set; }
        public string ReferenceNo { get; set; }
        public virtual ICollection<SelectedElement> SelectedElement { get; set; }
        public virtual ICollection<CollectionModel_PriceList> CollectionModel_PriceList { get; set; }
        // public virtual ICollection<SampleAssortment> SampleAssortment { get; set; }
        //public virtual ICollection<SampleBom> SampleBom { get; set; }
        //public virtual ICollection<SampleDestination> SampleDestination { get; set; }
        //public virtual ICollection<StyleImage> StyleImage { get; set; }
    }
}
