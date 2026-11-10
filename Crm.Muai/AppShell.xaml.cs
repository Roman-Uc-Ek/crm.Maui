using Crm.Muai.Views;

namespace Crm.Muai
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Registrar las rutas que estan en la jerarquia visual del Shell
            Routing.RegisterRoute(nameof(CustomerEditPage),
                typeof(CustomerEditPage));
        }
    }
}
