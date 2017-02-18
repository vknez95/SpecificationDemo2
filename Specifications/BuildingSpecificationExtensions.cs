namespace SpecificationDemo.Specifications
{
    public static class BuildingSpecificationExtensions
    {
        public static bool SafeEquals<T>(this IBuildingSpecification<T> first,
                                         IBuildingSpecification<T> second)
        {
            bool firstNull = object.ReferenceEquals(first, null);
            bool secondNull = object.ReferenceEquals(second, null);

            return
                (firstNull && secondNull) ||
                (!firstNull && first.Equals(second));
        }
    }
}