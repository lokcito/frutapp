using System;
using Android.Content;
using frutappi.Activities;
using frutappi.Helpers;
using frutappi.Models;

namespace frutappi.Presenters
{
    public class MainPresenter
    {
        Context context;
        public MainPresenter(Context _context)
        {
            this.context = _context;
        }
        public void showCatalog(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this.context, typeof(CatalogActivity));
            this.context.StartActivity(newActivity);
        }
        public void showUsers(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this.context, typeof(UsersActivity));
            this.context.StartActivity(newActivity);
        }
        public void showCalculator(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this.context, typeof(CalculatoraActivity));
            this.context.StartActivity(newActivity);
        }
        public bool loadRow(object sender, EventArgs args)
        {
            Product o = new Product();
            o.id = 1;
            o.name = "kkk";
            o.description = "jkjjkjkjkjk";
            if (DatabaseHelper.insert(ref o, DatabaseHelper.locate(Settings.DATABASE_PATH)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
 
        public void showLocations(object sender, EventArgs args)
        {
            Intent newActivity = new Intent(this.context, typeof(LocationsActivity));
            this.context.StartActivity(newActivity);
        }
    }
}
