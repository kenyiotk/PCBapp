using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PCBapp.Model
{
    public class Products
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public static List<Product> local()
        {
            return new List<Product>() {
                new Product(){first_name = "Uno" },
                new Product(){first_name = "Dos" },
                new Product(){first_name = "Tres" },
                new Product(){first_name = "Cuatro" },
                new Product(){first_name = "Cinco" },
                new Product(){first_name = "Seis" },
                new Product(){first_name = "Siete" },
                new Product(){first_name = "Ocho" },
            };
        }
}