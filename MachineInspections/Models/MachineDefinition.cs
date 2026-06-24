using System;

using System.Collections.Generic;

namespace MachineInspections
{
    public class MachineDefinition
    {
        public DateTime LastInspectionDate { get; set; }
        public string LastInspectionType { get; set; }
        public string MachineName { get; set; }

        //Code - Definition
        public Dictionary<string, List<MaintenanceTest>>? Maintenance { get; set; }

        //Read from config all the maintenance interval e.g monthly, quarterly, yearly and their values in days : monthly - 30, weekly-7
        public Dictionary<string, int>? MaintenanceSchedule { get; set; }

        //Map
        public Dictionary<string, bool>? InspectionTimeOverdue { get; set; }

        public string? SerialNumber { get; set; }
    }
}
