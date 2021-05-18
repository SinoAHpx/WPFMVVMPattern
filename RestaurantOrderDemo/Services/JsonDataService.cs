using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using RestaurantOrderDemo.Models;

namespace RestaurantOrderDemo.Services
{
    public class JsonDataService : IDataService
    {
        public IEnumerable<Dish> GetDishes()
        {
            var path = @".\Data\DishesData.json";
            var text = File.ReadAllText(path, Encoding.Default);

            return JArray.Parse(text).Select(token => token.ToObject<Dish>()).ToList();
        }
    }
}