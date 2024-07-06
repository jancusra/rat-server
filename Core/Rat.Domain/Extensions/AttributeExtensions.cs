using System;
using System.Linq;
using System.Reflection;

namespace Rat.Domain.Extensions
{
    public static class AttributeExtensions
    {
        /// <summary>
        /// Determine if type (usually entity) has specific attribute
        /// </summary>
        /// <typeparam name="T">attribute type</typeparam>
        /// <param name="type">specific entity</param>
        /// <returns>the bool result if type has specific attribute</returns>
        public static bool HasSpecificAttribute<T>(this Type type) where T : Attribute
        {
            object[] attributes = type.GetCustomAttributes(false);

            if (attributes.Count() > default(int)
                && attributes.FirstOrDefault(x => x.GetType() == typeof(T)) != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determine if property (usually entity property) has specific attribute
        /// </summary>
        /// <typeparam name="T">attribute type</typeparam>
        /// <param name="type">specific property</param>
        /// <returns>the bool result if property has specific attribute</returns>
        public static bool HasSpecificAttribute<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            if (propertyInfo.CustomAttributes.Count() > default(int)
                && propertyInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(T)) != null)
            {
                return true;
            }

            return false;
        }
    }
}
