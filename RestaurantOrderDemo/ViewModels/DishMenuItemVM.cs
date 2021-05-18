using Prism.Mvvm;
using RestaurantOrderDemo.Models;

namespace RestaurantOrderDemo.ViewModels
{
    public class DishMenuItemVM : BindableBase
    {
        public Dish Dish { get; set; }
        private bool isSelected;

        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }
    }
}