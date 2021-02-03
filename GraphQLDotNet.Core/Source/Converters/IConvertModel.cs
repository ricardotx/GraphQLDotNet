namespace GraphQLDotNet.Core.Source.Converters
{
	public interface IConvertModel<TSource, TTarget>
	{
		TTarget Convert();
	}
}
