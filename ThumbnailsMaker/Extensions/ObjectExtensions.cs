using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace ThumbnailsMaker
{
    public static class ObjectExtensions
    {
        public static T DeepClone<T>(this T obj)
        {
            using var ms = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, obj);
            ms.Position = 0;

            return (T) formatter.Deserialize(ms);
        }
        
        public static void CloneNonNullValues(this object obj, object? targetObject)
        {
            if (obj is null || targetObject is null) return;
            
            var props = obj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !p.GetIndexParameters().Any())
                .Where(p => p.CanRead && p.CanWrite);

            foreach (var prop in props)
            {
                var value = prop.GetValue(obj, null);

                if (value == null) continue;
                
                var targetPropInfo = targetObject.GetType().GetProperty(prop.Name);
                if (targetPropInfo is null) continue;
                    
                if (PrimitiveTypes.Test(prop.PropertyType))
                {
                    var targetProperty = targetObject.GetType().GetProperty(prop.Name);
                    if (targetProperty is null) continue;

                    targetPropInfo.SetValue(targetObject, value);
                }
                else
                {
                    var targetObj = targetPropInfo.GetValue(targetObject);
                    CloneNonNullValues(value, targetObj);
                }
            }
        }
    }
}