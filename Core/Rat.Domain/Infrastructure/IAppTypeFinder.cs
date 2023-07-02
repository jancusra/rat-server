using Rat.Domain.Types;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rat.Domain.Infrastructure
{
    public partial interface IAppTypeFinder
    {
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        string GetAssemblyQualifiedNameByClass(string className, ClassType classType = ClassType.Class);

        PropertyInfo[] GetEntityPropertiesToMap(Type type);
    }
}
