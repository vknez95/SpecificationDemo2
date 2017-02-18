namespace SpecificationDemo.Specifications
{
    public static class BuildConvertingSpecification<TBase, TProduct> where TProduct : TBase
    {
        public static ConvertingSpecification<TBase, TProduct> From(IBuildingSpecification<TProduct> specification)
        {
            return new ConvertingSpecification<TBase, TProduct>(specification);
        }
    }
}