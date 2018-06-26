using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace frutappi.Fragments
{
    public class FragmentOne : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override void OnResume()
        {
            base.OnResume();
            System.Diagnostics.Debug.Print("-------------> On Resume");
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_one, container, false);

            return view;

            //return base.OnCreateView(Resource.Layout.fragment_one, container, savedInstanceState);
        }
    }
}