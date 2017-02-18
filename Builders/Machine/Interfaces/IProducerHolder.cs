using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Contracts;
using SpecificationDemo.Models;

namespace SpecificationDemo.Builders.Machine.Interfaces
{
    [ContractClass(typeof(ProducerHolderContracts))]
    public interface IProducerHolder
    {
        IModelHolder WithProducer(Producer producer);
    }
}
