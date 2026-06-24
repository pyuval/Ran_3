using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineInspections
{
    public class InspectionScheduleResult
    {
        public Dictionary<string, DateTime> NextDueDates { get; set; } = new Dictionary<string, DateTime>();

        //map key e.g : monthly to value: text
        public Dictionary<string, string> StatusMessages { get; set; } = new Dictionary<string, string>();

        public Dictionary<string, bool> InspectionTimeIsOverdue { get; set; } = new Dictionary<string, bool>();
        public string MostUrgentInterval { get; set; }
        public bool IsOverdue { get; set; }


        public InspectionScheduleResult CalculateSchedule(MachineDefinition machine)
        {
            var result = new InspectionScheduleResult();
            DateTime today = DateTime.Today;

            if (machine?.MaintenanceSchedule == null)
                return result;

            // Maintenance schedule maps interval names to intervals in days
            foreach (var interval in machine.MaintenanceSchedule)
            {
                string name = interval.Key;
                int days = interval.Value;

                DateTime nextDue = machine.LastInspectionDate.AddDays(days);
                result.NextDueDates[name] = nextDue;

                if (today > nextDue)
                {
                    int late = (today - nextDue).Days;
                    result.StatusMessages[name] = $"*{Translate(name)} באיחור של {late} ימים";
                    result.InspectionTimeIsOverdue[name] = true;
                    result.IsOverdue = true;
                        

                }
                else if (today == nextDue)
                {
                    result.StatusMessages[name] = $"*{Translate(name)} נדרשת היום";
                    result.InspectionTimeIsOverdue[name] = true;
                    result.IsOverdue = true;
                }
                else
                {
                    result.StatusMessages[name] = $"*{Translate(name)} הבאה: {nextDue:dd.MM.yyyy}";
                    result.InspectionTimeIsOverdue[name] = false;
                    result.IsOverdue = false;
                }
            }

            // Most urgent = earliest next due date
            //if (result.NextDueDates.Count > 0)
            //{
            //    result.MostUrgentInterval = result.NextDueDates
            //        .OrderBy(d => d.Value)
            //        .First().Key;
            //}

            return result;
        }

        public string Translate(string key)
        {
            switch (key)
            {
                case "שבועי":
                    return "בדיקה שבועית";

                case "חודשי":
                    return "בדיקה חודשית";

                case "דו חודשי":
                    return "בדיקה דו־חודשית";

                case "רבעוני":
                    return "בדיקה תלת־חודשית";

                case "חצי שנתי":
                    return "בדיקה חצי־שנתית";

                case "שנתי":
                    return "בדיקה שנתית";

                default:
                    return key;
            }
        }
    }
}