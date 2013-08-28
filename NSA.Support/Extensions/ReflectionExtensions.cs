using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSA.Support.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> ConcreteSubclassesOf(this Assembly assembly, Type type)
        {
            if (type.IsGenericTypeDefinition)
                return assembly.GetTypes().AsParallel().Where(x => !x.IsAbstract && InherithsFromGenericTypeDefinition(x, type));

            return assembly.GetTypes().AsParallel().Where(x => !x.IsAbstract && type.IsAssignableFrom(x));
        }

        private static bool InherithsFromGenericTypeDefinition(Type type, Type genericType)
        {
            if (type == null)
                return false;

            if (type.IsGenericTypeDefinition && type == genericType)
                return true;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                return true;

            return InherithsFromGenericTypeDefinition(type.BaseType, genericType);
        }
    }
}