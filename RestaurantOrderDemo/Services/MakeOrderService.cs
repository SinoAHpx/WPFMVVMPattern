using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantOrderDemo.Models;

namespace RestaurantOrderDemo.Services
{
    public class MakeOrderService : IOrderService
    {
        public void PlaceOrder(IEnumerable<Dish> dishes)
        {
            File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\OrderList.json",
                JsonConvert.SerializeObject(dishes));
        }
    }
}