using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Specifications.LegalEntity.Interfaces
{
    public interface IExpectOtherContact
    {
        IExpectOtherContact WithOtherContact(IBuildingSpecification<IContactInfo> contactSpec);
        IBuildingSpecification<Models.LegalEntity> AndNoMoreContacts();
    }
}