using Rat.Domain.Types;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Rat.Domain.Infrastructure
{
    /// <summary>
    /// Define class for a reflection operation (generally used for a dynamic library scanning)
    /// </summary>
    public partial interface IAppTypeFinder
    {
        /// <summary>
        /// Find a specific classes in libraries
        /// </summary>
        /// <typeparam name="T">class to find</typeparam>
        /// <param name="onlyConcreteClasses">only concrete classes (not abstract)</param>
        /// <returns>found types of specific class</returns>
        IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// Get assembly full name by specific class name (usually entity name)
        /// </summary>
        /// <param name="className">class/entity name</param>
        /// <param name="classType">type of class to get</param>
        /// <returns>full assembly name</returns>
        string GetAssemblyQualifiedNameByClass(string className, ClassType classType = ClassType.Class);

        /// <summary>
        /// Get entity properties to map as table columns
        /// </summary>
        /// <param name="type">entity type</param>
        /// <returns>properties to map as columns</returns>
        PropertyInfo[] GetEntityPropertiesToMap(Type type);
    }
}
