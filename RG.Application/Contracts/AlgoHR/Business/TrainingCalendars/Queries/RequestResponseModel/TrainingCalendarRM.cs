using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.TrainingCalendars.Queries.RequestResponseModel
{
    public class TrainingCalendarRM
    {
        public List<YearWiseMonth> YearWiseMonths { get; set; }
        public List<Day> WeekDays { get; set; }
        public List<CalendarDay> CalendarDays { get; set; }
    }
    public class YearWiseMonth
    {
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
    }

    public class DaysOfWeek
    {
        public List<Day> Days { get { return GetDaysOfWeek(); } }

        private List<Day> GetDaysOfWeek()
        {
            var days = new List<Day>();
            days.Add(new Day { DayNo = (int)DayOfWeek.Sunday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Sunday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Monday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Monday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Tuesday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Tuesday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Wednesday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Wednesday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Thursday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Thursday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Friday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Friday) });
            days.Add(new Day { DayNo = (int)DayOfWeek.Saturday, DayName = Enum.GetName(typeof(DayOfWeek), (int)DayOfWeek.Saturday) });
            return days;
        }
    }
    public class Day
    {
        public int DayNo { get; set; }
        public string DayName { get; set; }
    }

    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public int Day { get; set; }
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        public int WeekNo { get; set; }
        public int WeekDayNo { get; set; }
        public string WeekDayName { get; set; }
        public string Trainings { get; set; }
        public string SplittedTrainings { get { return Trainings != null ? Trainings.Replace("_ ", "<br/><br/>") :null; } }
        public string DayType { get; set; }
        public bool IsHoliday { get; set; }
    }
}
