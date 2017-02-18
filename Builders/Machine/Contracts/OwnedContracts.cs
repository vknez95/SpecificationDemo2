using System;
using System.Diagnostics.Contracts;
using SpecificationDemo.Builders.Machine.Interfaces;
using SpecificationDemo.Models;

namespace SpecificationDemo.Builders.Machine.Contracts
{
    [ContractClassFor(typeof(IOwned))]
    public abstract class OwnedContracts : IOwned
    {
        public IMachineBuilder OwnedBy(LegalEntity company)
        {
            Contract.Requires<ArgumentNullException>(company != null);
            return null;
        }
    }
}