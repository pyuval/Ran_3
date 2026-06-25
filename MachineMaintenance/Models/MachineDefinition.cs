using MachineMaintenance;
using System;

using System.Collections.Generic;

namespace MachineMaintenance.Models
{
    public class MachineDefinition
    {
        public DateTime LastInspectionDate { get; set; }
        public string LastInspectionType { get; set; }
        public string MachineName { get; set; }

        //Code - Definition
        public Dictionary<string, List<MaintenanceTest>>? MaintenanceDateToCodeDesc { get; set; } = new Dictionary<string, List<MaintenanceTest>>();

        //Read from config all the maintenance interval e.g monthly, quarterly, yearly and their values in days : monthly - 30, weekly-7
        public Dictionary<string, int>? MaintenanceSchedule { get; set; } = new Dictionary<string, int>();

        //Map
        public Dictionary<string, bool>? InspectionTimeOverdue { get; set; }

        public string? SerialNumber { get; set; }

        public bool IsOperational { get; set; } = true;

        public MachineDefinition() { }
    }
}
    