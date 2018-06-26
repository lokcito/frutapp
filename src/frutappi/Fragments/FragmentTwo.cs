﻿using System;
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
using frutappi.Presenters;

namespace frutappi.Fragments
{
    public class FragmentTwo : Fragment

    {
        Button btnone;
        FragmentTwoPresenter presenter;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View instance = inflater.Inflate(Resource.Layout.fragment_two, container, false);
            presenter = new FragmentTwoPresenter(instance.Context);
            btnone =  instance.FindViewById<Button>(Resource.Id.button1);
            btnone.Click += presenter.haceralgo;

            return instance;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}