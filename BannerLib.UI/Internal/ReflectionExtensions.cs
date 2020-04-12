using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace BannerLib.UI.Internal
{
    // I want it to throw nullrefs.
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    internal static class ReflectionExtensions
    {
        internal static void SetPublicPropertyValue(this object obj, string propName, object value)
        {
            obj.GetType()
                .GetProperty(propName)
                .SetValue(obj,value);
        }

        internal static T GetPublicPropertyValue<T>(this object obj, string propName)
        {
            return (T)obj.GetType()
                .GetProperty(propName)
                .GetValue(obj);
        }

        internal static T GetNonPublicFieldValue<T>(this object obj, string fieldName, bool baseType = false)
        {
            var type = obj.GetType();
            if (baseType) type = type.BaseType;
            return (T) type
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(obj);
        }
    }
}