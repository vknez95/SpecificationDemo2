using System;
using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Interfaces;
using SpecificationDemo.Models;

namespace SpecificationDemo.Builders.Machine.Contracts
{
    [ContractClassFor(typeof(IProducerHolder))]
    public abstract class ProducerHolderContracts : IProducerHolder
    {
        public IModelHolder WithProducer(Producer producer)
        {
            Contract.Requires<ArgumentNullException>(producer != null);
            return null;
        }
    }
}