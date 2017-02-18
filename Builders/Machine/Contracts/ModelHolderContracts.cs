using System;
using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Interfaces;

namespace SpecificationDemo.Builders.Machine.Contracts
{
    [ContractClassFor(typeof(IModelHolder))]
    public class ModelHolderContracts : IModelHolder
    {
        public IOwned WithModel(string model)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(model));
            return null;
        }
    }
}