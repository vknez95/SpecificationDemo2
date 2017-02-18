using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Contracts;

namespace SpecificationDemo.Builders.Person.Interfaces
{
    [ContractClass(typeof(FirstNameHolderContracts))]
    public interface IFirstNameHolder
    {
        ILastNameHolder WithFirstName(string name);
        [Pure]
        bool IsValidFirstName(string name);
    }
}
