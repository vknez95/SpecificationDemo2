namespace SpecificationDemo.Validation.Infrastructure
{
    internal class NotNull<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T obj) =>
            !object.ReferenceEquals(obj, null);
    }
}
