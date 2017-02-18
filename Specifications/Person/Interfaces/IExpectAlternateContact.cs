using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Specifications.Person.Interfaces
{
    public interface IExpectAlternateContact
    {
        IExpectAlternateContact WithAlternateContact<T>(IBuildingSpecification<T> contactSpec)
            where T : IContactInfo;
        bool CanAdd<T>(IBuildingSpecification<T> contactSpec) where T : IContactInfo;
        IBuildingSpecification<Models.Person> AndNoMoreContacts();
    }
}