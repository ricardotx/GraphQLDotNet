namespace GraphQLDotNet.Core.Source.Converters
{
	public interface IConvertModel<TSource, TTarget>
	{
		/// <summary>
		/// Convert a ApiModel to DataModel and backwards
		/// </summary>
		TTarget Convert();
	}
}
