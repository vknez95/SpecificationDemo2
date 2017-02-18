using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Contracts;
using SpecificationDemo.Models;

namespace SpecificationDemo.Builders.Machine.Interfaces
{
    [ContractClass(typeof(OwnedContracts))]
    public interface IOwned
    {
        IMachineBuilder OwnedBy(LegalEntity company);
    }
}