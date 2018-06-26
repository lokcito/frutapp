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
using frutappi.Fragments;

namespace frutappi.Activities
{
    [Activity(Label = "MainFragmentActivity")]
    public class MainFragmentActivity : Activity
    {
        bool showingTwoFragments;
        Button btnOne;
        Button btnTwo;
        Button btntres;
        FrameLayout playQuoteFragment;

        private void showTwo(object sender, EventArgs args)
        {
            changeFrame("two");
        }
        private void showOne(object sender, EventArgs args)
        {
            changeFrame("one");
        }
        private void show3(object sender, EventArgs args)
        {
            changeFrame("tres");
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main_fragment);
            playQuoteFragment = FindViewById<FrameLayout>(Resource.Id.fragmentMany);
            btnOne = FindViewById<Button>(Resource.Id.button1);
            btnTwo = FindViewById<Button>(Resource.Id.button2);
            btntres = FindViewById<Button>(Resource.Id.button3);
            btnOne.Click += showOne;
            btnTwo.Click += showTwo;
            btntres.Click += show3;


        }
        private void changeFrame(string _type) {
            FragmentTransaction ft = FragmentManager.BeginTransaction();

            if (_type.Equals("one"))
            {
                var quoteFrag = new FragmentOne();
                ft.Replace(Resource.Id.fragmentMany, quoteFrag);
            }
            else if (_type.Equals("tres")) {

                var quoteFrag = new Fragment3();
                ft.Replace(Resource.Id.fragmentMany, quoteFrag);
            }

            else
            {
                var quoteFrag = new FragmentTwo();
                ft.Replace(Resource.Id.fragmentMany, quoteFrag);
            }
            //ft.AddToBackStack(null);
            ft.SetTransition(FragmentTransit.FragmentFade);
            ft.Commit();
            
        }
    }
}