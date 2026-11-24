using CommunityToolkit.Mvvm.ComponentModel;
using Crm.Muai.Models;

namespace Crm.Muai.ViewModels
{
    public partial class CustomerDetailViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Customer _customer;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Item", out object? curremtItem))
            {
                Customer = (Customer) curremtItem;
            }
            query.Clear();
        }
    }
}
