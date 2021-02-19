using GraphQLDotNet.Core.Source.Converters;

using System.Collections.Generic;
using System.Linq;

namespace GraphQLDotNet.Core.Source.Extensions
{
	public static class ConvertExtensions
	{
		/// <summary>
		/// Convert a IEnumerable<Dto> into IEnumerable<Entity> and backwards
		/// </summary>
		public static IEnumerable<TTarget> ConvertAll<TSource, TTarget>(
			this IEnumerable<IConvertModel<TSource, TTarget>> models
		)
		{
			return models.Select(model => model.Convert());
		}
	}
}
