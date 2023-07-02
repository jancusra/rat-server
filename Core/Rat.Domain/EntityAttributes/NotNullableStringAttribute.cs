using System;

namespace Rat.Domain.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public partial class NotNullableStringAttribute : Attribute
    {
    
    }
}
