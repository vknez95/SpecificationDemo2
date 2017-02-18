using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Specifications.Person.Interfaces
{
    public interface IExpectPrimaryContact
    {
        IExpectAlternateContact WithPrimaryContact<T>(IBuildingSpecification<T> primaryContactSpec)
            where T : IContactInfo;
    }
}