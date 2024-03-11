using Android.OS;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppTv.Persistence
{
    public class DeviceInfo : IDeviceInfo
    {
        public string GetSerialNumber()
        {
            return Android.Provider.Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
        }

    }
}
