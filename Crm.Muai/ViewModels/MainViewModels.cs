using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Muai.Models;
using Crm.Muai.Persistence;
using System.Collections.ObjectModel;

namespace Crm.Muai.ViewModels
{
    public partial class MainViewModels : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Customer> _customers;

        [ObservableProperty]
        private bool _refreshing;

        [RelayCommand]
        private async Task LoadCustomersAsync()
        {
            await Task.Run(
                ()=>
                {
                    using CrmDbContext dbContext = new CrmDbContext();

                    Customers = new ObservableCollection<Customer>(dbContext.Custumers);

                    Refreshing = false;
                });
        }
        [RelayCommand]
        private void Showing()
        {
            Refreshing = true;
        }
    }
}
