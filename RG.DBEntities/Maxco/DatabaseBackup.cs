using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class DatabaseBackup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackupFlagFull { get; set; }
        public string BackupFlagLog { get; set; }
        public DateTime RetentionPeriodFull { get; set; }
        public DateTime RetentionPeriodLog { get; set; }
    }
}
