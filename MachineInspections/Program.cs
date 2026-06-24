using System.Windows.Forms;

namespace MachineInspections
{
    internal static class Program
    {
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MachineInspectionForm(login.LoggedInInspector));
                }
            }
        }
    }
}
