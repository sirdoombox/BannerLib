using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerLib.Gameplay
{
    static class Utils
    {
        public static object call(this object o, string methodName, params object[] args)
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
        public static List<TList> Remove<TList, TRemove>(this List<TList> list)
        {
            list.RemoveAll(item => item is TRemove);
            return list;
        }
    }
}
