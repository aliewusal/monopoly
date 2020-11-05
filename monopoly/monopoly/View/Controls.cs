using monopoly.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace monopoly.View.Controls
{
    public class FriendDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate freind { get; set; }
        public DataTemplate offerToFreind { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Friend)item).isOfferToFriend ? offerToFreind : freind;
        }
    }
}
