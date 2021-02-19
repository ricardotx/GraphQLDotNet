namespace GraphQLDotNet.Core.Source.Converters
{
	public interface IConvertModel<TSource, TTarget>
	{
		/// <summary>
		/// Convert a Dto into Entity and backwards
		/// </summary>
		TTarget Convert();
	}
}
