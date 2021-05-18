using System.Collections.Generic;
using RestaurantOrderDemo.Models;

namespace RestaurantOrderDemo.Services
{
    public interface IOrderService
    {
        void PlaceOrder(IEnumerable<Dish> dishes);
    }
}