﻿using System;
using System.Collections.Generic;

using Android.Views;

using DavideSteduto.FlexibleAdapter;
using DavideSteduto.FlexibleAdapter.Items;

namespace NSPersonalCloud.DevolMobile.Items
{
    internal class FolderGoBack : AbstractFlexibleItem
    {
        private readonly string upperLevelName;

        public FolderGoBack(string name)
        {
            upperLevelName = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override int LayoutRes => Resource.Layout.file_cell;

        public override Java.Lang.Object CreateViewHolder(View view, FlexibleAdapter adapter) => new FileEntryViewHolder(view, adapter);

        public override void BindViewHolder(FlexibleAdapter adapter, Java.Lang.Object viewHolder, int position, IList<Java.Lang.Object> payloads)
        {
            if (!(viewHolder is FileEntryViewHolder holder)) return;

            holder.R.file_cell_icon.SetImageResource(Resource.Drawable.folder_back);
            holder.R.file_cell_title.SetText(Resource.String.browser_back);
            if (string.IsNullOrEmpty(upperLevelName)) holder.R.file_cell_detail.Text = holder.Context.GetString(Resource.String.browser_back_to, holder.Context.GetString(Resource.String.devices_home));
            else holder.R.file_cell_detail.Text = holder.Context.GetString(Resource.String.browser_back_to, upperLevelName);
            holder.R.file_cell_size.Text = null;
            holder.R.file_cell_size.Visibility = ViewStates.Gone;
        }

        public override bool Equals(Java.Lang.Object o) => false;
    }
}
