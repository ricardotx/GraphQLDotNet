namespace GraphQLDotNet.Core.Source.Converters
{
	public interface IConvertModel<TSource, TTarget>
	{
		/// <summary>
		/// Convert a ApiModel into DataModel and backwards
		/// </summary>
		TTarget Convert();
	}
}
