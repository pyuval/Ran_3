using System;

using System.Linq;

namespace MachineInspections
{
    public class InspectionRecord
    {
        public string MachineName { get; set; }
        public string MachineSN { get; set; }
        public string Interval { get; set; }
        public DateTime LastInspectionDate { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
    }
}
