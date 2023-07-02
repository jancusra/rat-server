using System;

namespace Rat.Domain.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public partial class ForeignKeyAttribute : Attribute
    {
        public string TargetTableName { get; set; }

        public ForeignKeyAttribute(string targetTableName)
        {
            TargetTableName = targetTableName;
        }
    }
}
