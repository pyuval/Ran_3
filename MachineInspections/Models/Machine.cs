using System;

using System.Linq;

namespace MachineInspections
{
    public class Machine
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public bool Daily { get; set; }
        public bool Weekly { get; set; }
        public bool Monthly { get; set; }
        public bool BiMonthly { get; set; }
        public bool TriMonthly { get; set; }
        public bool MidYear { get; set; }
        public bool Annual { get; set; }
    }
}
