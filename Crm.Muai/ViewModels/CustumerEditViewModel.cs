using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Crm.Muai.Models;
using Crm.Muai.Persistence;

namespace Crm.Muai.ViewModels
{
    public partial class CustumerEditViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Customer _cust;
        protected Func<Customer, Task> ParentRefreshAcction { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query != null)
            {
                if (query.TryGetValue("Item",out var currentCustomer))
                {
                    Cust = (Customer) currentCustomer;
                }
                if (query.TryGetValue("ParameterRefreshsAction", out object? parentRefreshAction))
                {
                    ParentRefreshAcction=(Func<Customer, Task>) parentRefreshAction;
                }
                query.Clear();
            }
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            //Guardamos en la base de datos
            using CrmDbContext dbContext = new CrmDbContext();
            await dbContext.Custumers.AddAsync(Cust);
            //Agregamos al nuevo clienta a la coleccion Customer de la pantalla
            //padre invocando a ParentRefrestAction

            await ParentRefreshAcction(Cust);
            //Return a la pantalla father
            await Shell.Current.GoToAsync("..");
        }
    }
}
