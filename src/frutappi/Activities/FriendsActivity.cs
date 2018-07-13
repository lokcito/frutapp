
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
using FireSharp;
using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Interfaces;
using FireSharp.Response;
using frutappi.Adapters;
using frutappi.Models;

namespace frutappi.Activities
{
    [Activity(Label = "FriendsActivity")]
    public class FriendsActivity : Activity
    {

        ListView messaging;
        List<Toke> tokeList;
        TokeAdapter productAdapter;
        IFirebaseClient client;
        Button btnSend;
        EditText editText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_friends);



            messaging = FindViewById<ListView>(Resource.Id.messaging);
            btnSend = FindViewById<Button>(Resource.Id.btnSend);
            editText = FindViewById<EditText>(Resource.Id.editText);

            btnSend.Click += sendToke;

            tokeList = new List<Toke>() {
                //new Toke("uno"),
                //new Toke("dos"),
                //new Toke("tres"),
                //new Toke("cuatro"),
                //new Toke("cinco"),
                //new Toke("seis"),
                //new Toke("siete"),
            };
            productAdapter = new TokeAdapter(this, tokeList);
            messaging.Adapter = productAdapter;

            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "0iig8j7dZWhesQca1m8uFVf0l0Awnp7Ly34O9Qem",
                BasePath = "https://myxamarinproject-209715.firebaseio.com/"
            };

            client = new FirebaseClient(config);

            connect();
            // Create your application here
        }
        public async void sendToke(object sender, EventArgs o) {
            Toke toke = new Toke(editText.Text);
            FirebaseResponse response = await client.UpdateAsync("_root/messages", toke);
            Toke todo = response.ResultAs<Toke>();
            editText.Text = "";
            //System.Diagnostics.Debug.Print("------");
        }
        public async void connect()
        {
            FirebaseResponse response = await client.GetAsync("_root");
            stream();
        }

        public async void stream()
        {
            EventStreamResponse response = await client.OnAsync("_root/messages/text", added, changed, removed, this);
            ////Call dispose to stop listening for events
            //response.Dispose();
        }

        public void added(object sender, ValueAddedEventArgs args, object context)
        {
            System.Diagnostics.Debug.Print(">>added");
        }
        public void changed(object sender, ValueChangedEventArgs args, object context)
        {
            //System.Diagnostics.Debug.Print(">>changed");
            if (args.OldData != null && args.Data != null)
            {
                tokeList.Add(new Toke(args.Data));
                System.Diagnostics.Debug.Print(">>to list => " + args.Data);
                RunOnUiThread(() => productAdapter.NotifyDataSetChanged());
                RunOnUiThread(() => messaging.SetSelection((tokeList.Count - 1)));


            }
        }
        public void removed(object sender, ValueRemovedEventArgs args, object context)
        {
            System.Diagnostics.Debug.Print(">>removed");
        }
    }
}
