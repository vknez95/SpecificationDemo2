using System;

namespace SpecificationDemo.Validation.Infrastructure
{
    internal class Transform<T> : Specification<T>
    {

        private Func<bool, bool> Transformation { get; }
        private Specification<T> Subspecification { get; }

        public Transform(Func<bool, bool> transformation,
                                      Specification<T> specification)
        {
            this.Transformation = transformation;
            this.Subspecification = specification;
        }

        public override bool IsSatisfiedBy(T obj) =>
            this.Transformation(
                this.Subspecification.IsSatisfiedBy(obj));

    }
}
