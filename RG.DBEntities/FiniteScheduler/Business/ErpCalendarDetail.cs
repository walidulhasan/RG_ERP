using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class ErpCalendarDetail
    {
        public int Id { get; set; }
        public int CalendarId { get; set; }
        public DateTime CalendarDate { get; set; }
        public int CalendarDayTypeId { get; set; }
    }
}
