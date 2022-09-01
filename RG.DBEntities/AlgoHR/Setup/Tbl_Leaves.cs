using System;

namespace RG.DBEntities.AlgoHR.Setup
{
    public class Tbl_Leaves
    {
        public int Leaves_ID { get; set; }
        public string Leaves_Desc { get; set; }
        public bool? Leaves_Lapse { get; set; }
        public bool? Leaves_Encash { get; set; }
        public short? Leaves_Days { get; set; }
        public short? Leaves_Type { get; set; }
        public DateTime? Leaves_Created { get; set; }
        public string Leave_PCode { get; set; }
        public string Leave_Legend { get; set; }
        public bool Leave_UserDefinedOpeningBalance { get; set; }
        public string Leave_Gender { get; set; }
        public int MaxAvailDaysAtATime { get; set; }
        public int? LeaveDayIncrementDuration { get; set; }
        public bool IsDocumentRequired { get; set; }
        public int? DocumentRequiredForMoreThanDays { get; set; }
    }
}
