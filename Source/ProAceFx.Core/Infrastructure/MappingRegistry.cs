using System;
using AutoMapper;
using ProAceFx.Infrastructure;

namespace ProAceFx.Core.Infrastructure
{
	/// <summary>
	/// Provides a registry for mapping specifications stored through the AutoMapper framework.
	/// </summary>
	public class MappingRegistry : IMappingRegistry
	{
		/// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : class
		{
			return Mapper.Map<TSource, TDestination>(source);
		}

	    /// <summary>
	    /// Maps the source object to the specified destination type.
	    /// </summary>
	    /// <param name="destinationType"></param>
	    /// <param name="source"></param>
	    /// <param name="sourceType"></param>
	    /// <returns></returns>
	    public object Map(Type sourceType, Type destinationType, object source)
	    {
	        return Mapper.Map(source, sourceType, destinationType);
	    }
	}
}
