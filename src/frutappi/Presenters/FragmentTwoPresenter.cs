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
using frutappi.Activities;

namespace frutappi.Presenters
{
    class FragmentTwoPresenter
    {
        Context context;
        public FragmentTwoPresenter(Context _context)
        {
            this.context = _context;
        }
        public void haceralgo(object sender, EventArgs args)
        {
            System.Diagnostics.Debug.Print("presente-------------");
        }
    }
}