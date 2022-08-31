using System;
using System.Linq;
using System.Reflection;

namespace WcfGameStore.Utils
{
    //rozszerzenie klasy, funkcja statyczna, klasa generyczna, która używa 2 typów T1 i T2, 
    public static class PropertyUtils
    {
        public static void AutomatedCopyingConstructor<T, T2>(this T targetObject, T2 sourceObject) where T : class where T2 : class // typy musza być obiektami klas, nie mogą być wartością
        {
            //dla każdego property w typeof iteruje po wszystkich properties - readonly inicjalizowany tylko w konstruktorze 
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanWrite))
            {
                //check wyrażenie lambda prop sprawdzamy czy aktualny iterowany property ma taka sama nazwę jak properties
                Func<PropertyInfo, bool> CheckIfPropertyExistSource =
                    prop => string.Equals(property.Name, prop.Name, StringComparison.InvariantCultureIgnoreCase)
                    && prop.PropertyType.Equals(property.PropertyType);
                //sprawdzaym czy choć jeden paramert ma wartość - jak nie ma to null
                if (sourceObject.GetType().GetProperties().Any(CheckIfPropertyExistSource))
                {
                    property.SetValue(targetObject,sourceObject.GetPropertyValue(property.Name), null);
                }
            }
        }
        // funkcja generyczna zwraca dowolny obiekt - wartość
        private static object GetPropertyValue<T>(this T source, string propertyName)
        {
            return source.GetType().GetProperty(propertyName).GetValue(source, null);
        }
    }
}