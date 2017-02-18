using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Interfaces;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Builders.Person.Contracts
{
    [ContractClassFor(typeof(ISecondaryContactHolder))]
    public abstract class SecondaryContactHolderContracts : ISecondaryContactHolder
    {

        public abstract bool Contains(IContactInfo contact);

        public ISecondaryContactHolder WithSecondaryContact(IContactInfo contact)
        {
            Contract.Requires(contact != null);
            Contract.Requires(!this.Contains(contact));
            return null;
        }

        public abstract IPersonBuilder AndNoMoreContacts();

    }
}