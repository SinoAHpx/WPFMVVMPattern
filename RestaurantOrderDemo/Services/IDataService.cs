using System.Collections.Generic;
using RestaurantOrderDemo.Models;

namespace RestaurantOrderDemo.Services
{
    public interface IDataService
    {
        IEnumerable<Dish> GetDishes();
    }
}