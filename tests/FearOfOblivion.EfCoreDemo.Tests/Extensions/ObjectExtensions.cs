using System.Reflection;

namespace FearOfOblivion.EfCoreDemo.Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static T GetPrivateValue<T>(this object obj, string fieldName)
        {
            var prop = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (prop == null)
            {
                return default;
            }

            return (T)prop.GetValue(obj);
        }
    }
}
