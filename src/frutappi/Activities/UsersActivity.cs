
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
    [Activity(Label = "UsersActivity")]
    public class UsersActivity : Activity
    {
        ListView listViewUsers;
        List<User> userList = new List<User>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_users);
            listViewUsers = FindViewById<ListView>(Resource.Id.listViewUsers);
            //productList = DatabaseHelper.getProducts(DatabaseHelper.locate(Settings.DATABASE_PATH)); //Obtiene productos de SQLite
            //productList = Product.local(); //Obtiene productos de estaticos
            userList = User.sync(); //Obtiene productos de la nube

            UserAdapter userAdapter = new UserAdapter(this, userList);
            listViewUsers.Adapter = userAdapter;
            // Create your application here
        }
    }
}
