using System;

namespace SpecificationDemo.Validation.Infrastructure
{
    internal class Predicate<T> : Specification<T>
    {
        private Func<T, bool> Delegate { get; }

        public Predicate(Func<T, bool> predicate)
        {
            this.Delegate = predicate;
        }

        public override bool IsSatisfiedBy(T obj) =>
            this.Delegate(obj);

    }
}
