using Crm.Muai.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Muai
{
    public partial class App : Application
    {
        public App()
        {
            SQLitePCL.Batteries_V2.Init();
            using var context = new CrmDbContext();
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}