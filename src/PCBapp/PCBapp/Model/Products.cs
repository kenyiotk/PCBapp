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

using RestSharp;
using RestSharp.Deserializers;
using SimpleJson;


namespace PCBapp.Model
{
    public class Products
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public static List<Products> local()
        {
            return new List<Products>() {
                new Products(){first_name = "Uno" },
                new Products(){first_name = "Dos" },
                new Products(){first_name = "Tres" },
                new Products(){first_name = "Cuatro" },
                new Products(){first_name = "Cinco" },
                new Products(){first_name = "Seis" },
                new Products(){first_name = "Siete" },
                new Products(){first_name = "Ocho" },
            };
        }
        public static RestClient get(int id, Func<Products, int> toDo)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = String.Format("api/users/{0}", id);

            IRestResponse response = client.Execute(request);
            ProductObjectRest rootObject = null;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                rootObject = deserial.Deserialize<ProductObjectRest>(response);
                //return rootObject.data;
            }
            else
            {
                rootObject = new ProductObjectRest();
                //return rootObject.data;
            }

            toDo(rootObject.data);
            return client;
        }
        public static List<Products> sync()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/users";

            IRestResponse response = client.Execute(request);
            ProductRest rootObject;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                rootObject = deserial.Deserialize<ProductRest>(response);
                //return rootObject.data;
            }
            else
            {
                rootObject = new ProductRest();
                //return rootObject.data;
            }
            return rootObject.data;
        }
        public static RestClient sync(Func<List<Products>, int> toDo)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/users";

            IRestResponse response = client.Execute(request);
            ProductRest rootObject;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                rootObject = deserial.Deserialize<ProductRest>(response);
                //return rootObject.data;
            }
            else
            {
                rootObject = new ProductRest();
                //return rootObject.data;
            }
            toDo(rootObject.data);
            return client;
        }
    }
    public class ProductRest
    {
        public List<Products> data { get; set; }
    }
    public class ProductObjectRest
    {
        public Products data { get; set; }
    }

}