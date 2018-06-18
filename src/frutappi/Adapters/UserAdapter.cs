using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using frutappi.Models;

namespace frutappi.Adapters
{
    class UserAdapter : BaseAdapter<User>
    {

        Context context;
        List<User> list;

        public UserAdapter(Context context, List<User> _list)
            : base()
        {
            this.context = context;
            this.list = _list;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            UserAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as UserAdapterViewHolder;

            if (holder == null)
            {
                holder = new UserAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.adapter_user_item, parent, false);
                holder.FirstName = view.FindViewById<TextView>(Resource.Id.textFirstName);
                holder.LastName = view.FindViewById<TextView>(Resource.Id.textLastName);
                holder.Image = view.FindViewById<ImageView>(Resource.Id.imageUser);
                view.Tag = holder;
            }


            //fill in your items
            holder.FirstName.Text = list[position].first_name;
            holder.LastName.Text = list[position].last_name;
            Bitmap imageBitmap = GetImageBitmapFromUrl(list[position].avatar);
            holder.Image.SetImageBitmap(imageBitmap);

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return list.Count;
            }
        }

        public override User this[int position]
        {
            get
            {
                return list[position];
            }
        }
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }
    }

    class UserAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView FirstName { get; set; }
        public TextView LastName { get; set; }
        public ImageView Image { get; set; }
    }
}