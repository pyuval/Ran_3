using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance
{
    public class MachineDefinition
    {
        public string MachineName { get; set; }
        public string SerialNumber { get; set; }
        public Dictionary<string, int> MaintenanceSchedule { get; set; }

        public DateTime LastInspectionDate { get; set; }
        public string LastInspectionType { get; set; }

        public Dictionary<string, List<MaintenanceTest>> Maintenance { get; set; }
    }
}
