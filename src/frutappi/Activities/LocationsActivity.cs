
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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;

namespace frutappi.Activities
{
    [Activity(Label = "LocationsActivity")]
    public class LocationsActivity : Activity, IOnMapReadyCallback
    {
        private MapFragment mapFragment;
        private GoogleMap gMap;

        private static readonly LatLng place = new LatLng(-12.065845, -75.212444);


        public void OnMapReady(GoogleMap googleMap)
        {
            this.gMap = googleMap;
            //LocationManager locationManager = (LocationManager)GetSystemService(LocationService);


            this.locate();
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_map);
            setUp();
        }
        private void setUp()
        {
            mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (mapFragment == null)
            {
                //.InvokeMapType(GoogleMap.MapTypeSatellite)
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);
                mapFragment = MapFragment.NewInstance(mapOptions);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                fragTx.Add(Resource.Id.googlemaps, mapFragment, "map");
                fragTx.Commit();
            }
            mapFragment.GetMapAsync(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
        private void locate()
        {

            // Move the camera to the Passchendaele Memorial in Belgium.
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(place);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);
            CameraPosition cameraPosition = builder.Build();

            // AnimateCamera provides a smooth, animation effect while moving
            // the camera to the the position.

            this.gMap.AnimateCamera(CameraUpdateFactory.NewCameraPosition(cameraPosition));
        }


    }
}
