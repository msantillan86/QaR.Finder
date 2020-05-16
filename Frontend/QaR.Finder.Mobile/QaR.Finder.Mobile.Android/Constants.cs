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

namespace QaR.Finder.Mobile.Droid
{
    public static class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://qarfinderhubnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=NvD7aCbRSfQRF4WwHSeUKYXMdE1b++jeiM6p7vBOyXM=";
        public const string NotificationHubName = "QarFinderHub";
    }
}