using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using FluentMigrator.Expressions;
using LinqToDB.Mapping;
using LinqToDB.Metadata;
using LinqToDB.SqlQuery;
using Rat.Domain;
using Rat.Domain.EntityAttributes;

namespace Rat.DataStorage.Mapping
{
    public partial class FluentMigratorMetadataProvider : IMetadataReader
    {
        protected T GetAttribute<T>(Type type, MemberInfo memberInfo) where T : Attribute
        {
            var attribute = Types.GetOrAdd((type, memberInfo), t =>
            {
                if (typeof(T) == typeof(TableAttribute))
                {
                    return new TableAttribute(type.Name);
                }

                if (typeof(T) != typeof(ColumnAttribute) || memberInfo is null)
                {
                    return null;
                }

                var columnSystemType = (memberInfo as PropertyInfo)?.PropertyType ?? typeof(string);
                var columnSize = default(int);
                var canBeNull = false;
                object[] attributes = memberInfo.GetCustomAttributes(true);

                if (columnSystemType == typeof(string))
                {
                    var maxStringLengthAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(MaxStringLengthAttribute));
                    var notNullableStringAttribute = attributes.FirstOrDefault(x => x.GetType() == typeof(NotNullableStringAttribute));
                    canBeNull = true;

                    if (maxStringLengthAttribute != null)
                    {
                        var attributeStringData = maxStringLengthAttribute as MaxStringLengthAttribute;
                        columnSize = attributeStringData.MaxStringLength;
                    }

                    if (notNullableStringAttribute != null)
                    {
                        canBeNull = false;
                    }
                }

                if (columnSystemType == typeof(bool?) || columnSystemType == typeof(int?)
                    || columnSystemType == typeof(long?) || columnSystemType == typeof(decimal?)
                    || columnSystemType == typeof(DateTime?) || columnSystemType == typeof(Guid?))
                {
                    canBeNull = true;
                }

                return new ColumnAttribute
                {
                    Name = memberInfo.Name,
                    IsPrimaryKey = memberInfo.Name == "Id",
                    IsColumn = true,
                    CanBeNull = canBeNull,
                    Length = columnSize,
                    Precision = default(int),
                    IsIdentity = memberInfo.Name == "Id",
                    DataType = SqlDataType.GetDataType(columnSystemType).Type.DataType
                };
            });

            return (T)attribute;
        }

        protected T[] GetAttributes<T>(Type type, Type attributeType, MemberInfo memberInfo = null)
            where T : Attribute
        {
            if (type.IsSubclassOf(typeof(TableEntity)) && typeof(T) == attributeType && GetAttribute<T>(type, memberInfo) is T attr)
            {
                return new[] { attr };
            }

            return Array.Empty<T>();
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Attributes owner type.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(TableAttribute));
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type member.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Member's owner type.</param>
        /// <param name="memberInfo">Attributes owner member.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(ColumnAttribute), memberInfo);
        }

        /// <summary>
        /// Gets the dynamic columns defined on given type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>All dynamic columns defined on given type</returns>
        public MemberInfo[] GetDynamicColumns(Type type)
        {
            return Array.Empty<MemberInfo>();
        }

        protected static ConcurrentDictionary<(Type, MemberInfo), Attribute> Types { get; } = new ConcurrentDictionary<(Type, MemberInfo), Attribute>();
        protected static ConcurrentDictionary<Type, CreateTableExpression> Expressions { get; } = new ConcurrentDictionary<Type, CreateTableExpression>();
    }
}
