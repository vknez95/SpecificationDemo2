using System;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Common
{
    internal class UninitializedPrimaryContact: IPrimaryContactState
    {

        private Func<IContactInfo, bool> Predicate { get; }

        public UninitializedPrimaryContact(Func<IContactInfo, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException();

            this.Predicate = predicate;

        }

        public IPrimaryContactState Set(IContactInfo contact) =>
            new ValidPrimaryContact(contact, this.Predicate);

        public IContactInfo Get()
        {
            throw new System.InvalidOperationException();
        }
    }
}
