using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Muai.Models;
using Crm.Muai.Persistence;
using Crm.Muai.Views;
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

                    this.Customers = new ObservableCollection<Customer>
                    (dbContext.Customers);

                    Refreshing = false;
                });
        }

        [RelayCommand]
        private void Showing()
        {
            Refreshing = true;
        }
        [RelayCommand]
        private async Task ShowNewCustomerForAsync()
        {
           await Shell.Current.GoToAsync(
               nameof(CustomerEditPage), 
               parameters:new Dictionary<string,object>
           {
                   {"ParameterRefreshAction", (Func<Customer,Task>)RefreshAddedAsync},
                   {"Item", new Customer() },
           });


        }
        private Task RefreshAddedAsync(Customer AddedCustomer) 
        {
            Customers.Add(AddedCustomer);
            return  Task.CompletedTask;
        }
    }
}
