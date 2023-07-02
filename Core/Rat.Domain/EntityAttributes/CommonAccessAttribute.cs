using System;

namespace Rat.Domain.EntityAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public partial class CommonAccessAttribute : Attribute
    {

    }
}
