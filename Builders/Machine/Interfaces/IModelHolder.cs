using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Contracts;

namespace SpecificationDemo.Builders.Machine.Interfaces
{
    [ContractClass(typeof(ModelHolderContracts))]
    public interface IModelHolder
    {
        IOwned WithModel(string model);
    }
}