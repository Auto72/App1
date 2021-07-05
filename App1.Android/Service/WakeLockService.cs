using Android.Content;
using Android.OS;
using App1.Service;
using System;
using static Android.OS.PowerManager;

namespace App1.Droid.Service
{
    public class WakeLockService : IWakeLockService
    {
        public void SetupWakeLock(long duration)
        {
            try
            {
                PowerManager powerManager = (PowerManager)Android.App.Application.Context.GetSystemService(Context.PowerService);

                // Is the screen off ?
                if (powerManager.IsInteractive == false)
                {
                    // Yes
                    WakeLock wakeLock = powerManager.NewWakeLock(WakeLockFlags.Partial, "MyWakeLock");
                    wakeLock.Acquire(duration);
                    System.Diagnostics.Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} wakeLock.Acquire() called");
                }
                else { System.Diagnostics.Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Screen not locked."); }

            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} SetupWakeLock() Exception --> {ex.Message}");
            }
        }
    }
}