using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Business
{
    public class vw_GetOrderDetailByModel
    {
        public long RowSl { get; set; }
        /// <summary>
        /// style Id
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Order Id
        /// </summary>
        public long ParentID { get; set; }
        public int BuyerID { get; set; }
        public int SelectedElementID { get; set; }
        //public int CountryId { get; set; }
        public int FabricCategoryID { get; set; }
        public string Description { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public string CollectionName { get; set; }
        public string SeasonName { get; set; }
        public string GProTypeName { get; set; }
        public int Year { get; set; }
        public string FabricCategoryName { get; set; }
        public DateTime CreationDate { get; set; }
        public string ReferenceNo { get; set; }
        public int OrderStyleElementID { get; set; }
        public int? FabricTrimSelectedID { get; set; }
        //public int CompanyId { get; set; }
        public int? FabricTrimId { get; set; }


    }
}
