using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Person.Contracts;

namespace SpecificationDemo.Builders.Person.Interfaces
{
    [ContractClass(typeof(LastNameHolderContracts))]
    public interface ILastNameHolder
    {
        IPrimaryContactHolder WithLastName(string surname);
        [Pure]
        bool IsValidLastName(string surname);
    }
}