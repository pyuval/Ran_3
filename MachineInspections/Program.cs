using MachineInspections.Forms;
using System.Windows.Forms;

namespace MachineInspections
{
    internal static class Program
    {
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var machines = new List<string>
        {
            "BOSCH BAR",
            "PHILLIPS LASER",
            "Siemens Bar",
            "Lavazza"
        };
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MachineSelectionForm(login.LoggedInInspector, machines));
                    // Application.Run(new MachineInspectionForm(login.LoggedInInspector));
                }
            }
        }
    }
}
