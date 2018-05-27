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
using frutappi.Adapters;
using frutappi.Models;

namespace frutappi.Activities
{
    [Activity(Label = "CatalogActivity")]
    public class CatalogActivity : Activity
    {
        ListView listViewCatalog;
        List<Product> productList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_catalog);

            listViewCatalog = FindViewById<ListView>(Resource.Id.listViewProducts);
            productList = new List<Product>() {
                new Product(){name = "Uno" },
                new Product(){name = "Dos" },
                new Product(){name = "Tres" },
                new Product(){name = "Cuatro" },
                new Product(){name = "Cinco" },
                new Product(){name = "Seis" },
                new Product(){name = "Siete" },
                new Product(){name = "Ocho" },
            };
            ProductAdapter productAdapter = new ProductAdapter(this, productList);
            listViewCatalog.Adapter = productAdapter;

            // Create your application here
        }
    }
}