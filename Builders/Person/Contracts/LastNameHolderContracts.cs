using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Interfaces;

namespace SpecificationDemo.Builders.Person.Contracts
{
    [ContractClassFor(typeof(ILastNameHolder))]
    public abstract class LastNameHolderContracts : ILastNameHolder
    {
        public abstract bool IsValidLastName(string surname);

        public IPrimaryContactHolder WithLastName(string surname)
        {
            Contract.Requires(this.IsValidLastName(surname));
            return null;
        }
    }
}