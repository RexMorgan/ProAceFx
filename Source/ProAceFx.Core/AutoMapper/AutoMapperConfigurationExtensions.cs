using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;

namespace ProAceFx.Core.AutoMapper
{
    /// <summary>
    /// Provides an orchestration mechanism for automatically triggering mappers for the AutoMapper framework.
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Creates all maps in the assembly in which the specified mapper type is declared.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        /// <typeparam name="TMap">Type of mapper.</typeparam>
        public static void AddAllFromAssemblyContainingType<TMap>(this IConfiguration configuration)
            where TMap : IMapper
        {
            AddAllFromAssemblyContainingType<TMap>(configuration, true);
        }
        /// <summary>
        /// Creates all maps in the assembly in which the specified mapper type is declared.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        /// <param name="useServiceLocator">Flag indicating whether to use service locator for mappers.</param>
        /// <typeparam name="TMap">Type of mapper.</typeparam>
        public static void AddAllFromAssemblyContainingType<TMap>(this IConfiguration configuration, bool useServiceLocator)
            where TMap : IMapper
        {
            var mappers = FindMapsFromAssembly(typeof(TMap).Assembly, useServiceLocator);
            foreach (var mapper in mappers)
            {
                mapper.CreateMap(configuration);
            }
        }
        /// <summary>
        /// Finds all maps from the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to load from.</param>
        /// <returns></returns>
        public static IEnumerable<IMapper> FindMapsFromAssembly(Assembly assembly)
        {
            return FindMapsFromAssembly(assembly, true);
        }
        /// <summary>
        /// Finds all maps from the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly to load from.</param>
        /// <param name="useServiceLocator">Flag indicating whether to use service locator for mappers.</param>
        /// <returns></returns>
        public static IEnumerable<IMapper> FindMapsFromAssembly(Assembly assembly, bool useServiceLocator)
        {
            Func<Type, object> serviceLocator = (type => Activator.CreateInstance(type));
            if (useServiceLocator)
            {
                serviceLocator = t => ServiceLocator.Current.GetInstance(t);
            }

            Type mapType = typeof(IMapper);
            Type[] types;
            try
            {
                types = assembly.GetExportedTypes();
            }
            catch (NotSupportedException) // Dynamic assemblies
            {
                yield break;
            }

            foreach (Type type in types.Where(t => mapType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface))
            {
                yield return (IMapper)serviceLocator(type);
            }
        }
    }
}