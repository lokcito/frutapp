using System;
using System.Collections.Generic;
using System.Linq;
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
    class TokeAdapter : BaseAdapter<Toke>
    {

        Context context;
        List<Toke> list;

        public TokeAdapter(Context context, List<Toke> _list)
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
            TokeAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as TokeAdapterViewHolder;

            if (holder == null)
            {
                holder = new TokeAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                view = inflater.Inflate(Resource.Layout.adapter_toke_item, parent, false);
                holder.Name = view.FindViewById<TextView>(Resource.Id.text);
                //holder.Image = view.FindViewById<ImageView>(Resource.Id.imageProduct);
                view.Tag = holder;
            }


            //fill in your items
            holder.Name.Text = list[position].text;
            //holder.Image.SetColorFilter(Color.ParseColor(list[position].color + "00"));// Background.set = list[position].color;

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

        public override Toke this[int position]
        {
            get
            {
                return list[position];
            }
        }
    }

    class TokeAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        public TextView Name { get; set; }
        //public ImageView Image { get; set; }
    }
}