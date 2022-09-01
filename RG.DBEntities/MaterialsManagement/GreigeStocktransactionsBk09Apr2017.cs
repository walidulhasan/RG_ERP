using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class GreigeStocktransactionsBk09Apr2017
    {
        [Key]
        public long StockTransactionId { get; set; }
        public int DocumentNo { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int ProgramTypeId { get; set; }
        public int? OrderId { get; set; }
        public int? StyleId { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Skuunit { get; set; }
        public double RateWrtbaseUnit { get; set; }
        public double Quantity { get; set; }
        public int? NoOfRolls { get; set; }
        public int? NoOfPieces { get; set; }
        public int Status { get; set; }
        public int? Ykncid { get; set; }
        public int? RollId { get; set; }
        public int? QualityId { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public int? StoreLocationId { get; set; }
        public string RollNo { get; set; }
        public int? MachineId { get; set; }
        public string Comments { get; set; }
        public int? Rollnonew { get; set; }
        public string Rollnop { get; set; }
    }
}
