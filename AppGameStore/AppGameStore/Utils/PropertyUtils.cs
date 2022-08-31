using System;
using System.Linq;
using System.Reflection;

namespace AppGameStore.Utils
{
    public static class PropertyUtils
    {
        public static void AutomatedCopyingConstructor<T, T2>(this T targetObject, T2 sourceObject)
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                Func<PropertyInfo, bool> CheckIfPropertyExistSource =
                    prop => string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);

                if (sourceObject.GetType().GetProperties().Any(CheckIfPropertyExistSource))
                {
                    property.SetValue(targetObject, sourceObject.GetPropertyValue(property.Name), null);
                }
            }
        }
        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }
    }
}
