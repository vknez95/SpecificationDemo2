using System;

namespace SpecificationDemo.Validation.Infrastructure
{
    internal class Property<TType, TProperty> : Specification<TType>
    {

        private Func<TType, TProperty> PropertyGetter { get; }
        private Specification<TProperty> Subspecification { get; }

        public Property(Func<TType, TProperty> propertyGetter,
                                     Specification<TProperty> subspecification)
        {
            this.PropertyGetter = propertyGetter;
            this.Subspecification = subspecification;
        }

        public override bool IsSatisfiedBy(TType obj) =>
            this.Subspecification.IsSatisfiedBy(
                this.PropertyGetter(obj));

    }
}
