using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WashingProcessSequence
    {
        public long SequenceId { get; set; }
        public long? ParentProcessId { get; set; }
        public long? ChildProcessId { get; set; }
    }
}
