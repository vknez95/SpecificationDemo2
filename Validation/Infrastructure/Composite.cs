using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationDemo.Validation.Infrastructure
{
    internal class Composite<T> : Specification<T>
    {

        private Func<IEnumerable<bool>, bool> CompositionFunction { get; }
        private IEnumerable<Specification<T>> Subspecifications { get; }

        public Composite(Func<IEnumerable<bool>, bool> compositionFunction,
                                      params Specification<T>[] subspecifications)
        {
            this.CompositionFunction = compositionFunction;
            this.Subspecifications = subspecifications;
        }

        public override bool IsSatisfiedBy(T obj) =>
            this.CompositionFunction(
                this.Subspecifications.Select(spec => spec.IsSatisfiedBy(obj)));

    }
}
