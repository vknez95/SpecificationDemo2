using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Contracts;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Builders.Person.Interfaces
{
    [ContractClass(typeof(PrimaryContactHolderContracts))]
    public interface IPrimaryContactHolder : IContactHolder
    {
        ISecondaryContactHolder WithPrimaryContact(IContactInfo contact);
    }
}