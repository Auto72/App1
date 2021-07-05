using App1.Service;
using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    public static class Utils
    {
        public static void VibrateMobile(double duration = 500)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    DependencyService.Get<IWakeLockService>().SetupWakeLock((long)(duration + 100));
                }

                Vibration.Vibrate(TimeSpan.FromMilliseconds(duration));
            }
            catch (FeatureNotSupportedException ex1)
            {
                // Feature not supported on device 
                Debug.WriteLine($"VibrateMobile FeatureNotSupportedException --> {ex1.Message}");
            }
            catch (Exception ex)
            {
                // Other error has occurred
                Debug.WriteLine($"VibrateMobile Exception --> {ex.Message}");
            }
        }
    }
}
