using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Contracts;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Builders.Person.Interfaces
{
    [ContractClass(typeof(SecondaryContactHolderContracts))]
    public interface ISecondaryContactHolder : IContactHolder
    {
        ISecondaryContactHolder WithSecondaryContact(IContactInfo contact);
        IPersonBuilder AndNoMoreContacts();
    }
}