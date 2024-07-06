using System;

namespace Rat.Domain.EntityAttributes
{
    /// <summary>
    /// Specify quickly not nullable database string property
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public partial class NotNullableStringAttribute : Attribute
    {
    
    }
}
