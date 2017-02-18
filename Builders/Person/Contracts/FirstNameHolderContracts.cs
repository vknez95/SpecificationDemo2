using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Interfaces;

namespace SpecificationDemo.Builders.Person.Contracts
{
    [ContractClassFor(typeof(IFirstNameHolder))]
    public abstract class FirstNameHolderContracts : IFirstNameHolder
    {
        public abstract bool IsValidFirstName(string name);

        public ILastNameHolder WithFirstName(string name)
        {
            Contract.Requires(this.IsValidFirstName(name));
            return null;
        }

    }
}