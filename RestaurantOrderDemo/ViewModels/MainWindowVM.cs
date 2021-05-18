using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using RestaurantOrderDemo.Models;
using RestaurantOrderDemo.Services;

namespace RestaurantOrderDemo.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        private int count;

        public int Count
        {
            get => count;
            set
            {
                count = value;
                RaisePropertyChanged(nameof(Count));
            }
        }

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get => restaurant;
            set
            {
                restaurant = value;
                RaisePropertyChanged(nameof(restaurant));
            }
        }

        private List<DishMenuItemVM> dishMenu;

        public List<DishMenuItemVM> DishMenu
        {
            get => dishMenu;
            set
            {
                dishMenu = value;
                RaisePropertyChanged(nameof(DishMenu));
            }
        }

        public MainWindowVM()
        {
            Restaurant = new Restaurant
            {
                Address = "北京市海淀区万泉河路紫金庄园1号楼 1层 113室",
                Tel = "114514",
                Name = "Crazy大象"
            };

            var dishes = new JsonDataService().GetDishes();
            DishMenu = new List<DishMenuItemVM>();

            foreach (var dish in dishes)
            {
                DishMenu.Add(new DishMenuItemVM {Dish = dish});
            }

            PlaceOrderCommand = new DelegateCommand(() =>
            {
                var selectedDishes = DishMenu.Where(x => x.IsSelected);
                new MakeOrderService().PlaceOrder(selectedDishes.Select(x => x.Dish));

                MessageBox.Show("订餐成功!");
            });

            SelectItemCommand = new DelegateCommand(() =>
            {
                Count = DishMenu.Count(x => x.IsSelected);
            });
        }

        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectItemCommand { get; set; }
    }
}