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
using frutappi.Helpers;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using FireSharp.Response;
using FireSharp.EventStreaming;
//using Firebase.Database;

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
            //productList = DatabaseHelper.getProducts(DatabaseHelper.locate(Settings.DATABASE_PATH)); //Obtiene productos de SQLite
            //productList = Product.local(); //Obtiene productos de estaticos
            productList = Product.sync(); //Obtiene productos de la nube

            ProductAdapter productAdapter = new ProductAdapter(this, productList);
            listViewCatalog.Adapter = productAdapter;



        }
    }
}