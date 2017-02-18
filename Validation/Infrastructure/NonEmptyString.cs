namespace SpecificationDemo.Validation.Infrastructure
{
    internal class NonEmptyString : Specification<string>
    {
        public override bool IsSatisfiedBy(string obj) =>
            !string.IsNullOrEmpty(obj);
    }
}
