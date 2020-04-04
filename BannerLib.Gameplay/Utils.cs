using System;
using System.Diagnostics;

namespace BannerLib.Gameplay
{
    internal static class Utils
    {
        internal static object Call(this object o, string methodName, params object[] args)
        {
            var mi = o.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (mi != null)
            {
                try
                {
                    return mi.Invoke(o, args);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return null;
        }
    }
}
