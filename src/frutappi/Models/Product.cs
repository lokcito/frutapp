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
using Firebase.Database;
using RestSharp;
using RestSharp.Deserializers;
using SimpleJson;

namespace frutappi.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public static List<Product> local() {
            return new List<Product>() {
                new Product(){name = "Uno" },
                new Product(){name = "Dos" },
                new Product(){name = "Tres" },
                new Product(){name = "Cuatro" },
                new Product(){name = "Cinco" },
                new Product(){name = "Seis" },
                new Product(){name = "Siete" },
                new Product(){name = "Ocho" },
            };            
        }

        public static bool fireSync() {
            var userNamesRef = FirebaseDatabase.GetInstance("https://myxamarinproject-209715.firebaseio.com").GetReference("/");
            DataSnapshot o = userNamesRef.

            return false;
        }

        public static List<Product> sync() {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://reqres.in/");

            var request = new RestRequest();
            request.Resource = "api/products";

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
                ProductRest rootObject = deserial.Deserialize<ProductRest>(response);
                return rootObject.data;
            }
            else
            {
                ProductRest rootObject = new ProductRest();
                return rootObject.data;
            }
        }
    }
    public class ProductRest {
        public List<Product> data {get; set;}
    }
}