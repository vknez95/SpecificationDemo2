using System;

namespace SpecificationDemo.Specifications
{
    public class ConvertingSpecification<TBase, TProduct> :
        IBuildingSpecification<TBase> where TProduct : TBase
    {
        private IBuildingSpecification<TProduct> ContainedSpec { get; }

        public ConvertingSpecification(IBuildingSpecification<TProduct> containedSpec)
        {
            if (containedSpec == null)
                throw new ArgumentNullException();
            this.ContainedSpec = containedSpec;
        }

        public TBase Build() => this.ContainedSpec.Build();

        public bool Equals(IBuildingSpecification<TBase> other)
        {
            ConvertingSpecification<TBase, TProduct> convertingSpec =
                other as ConvertingSpecification<TBase, TProduct>;

            return 
                convertingSpec != null && 
                this.ContainedSpec.Equals(convertingSpec.ContainedSpec);
        }

        public override int GetHashCode() => this.ContainedSpec.GetHashCode();

        public override bool Equals(object obj) =>
            this.Equals(obj as IBuildingSpecification<TBase>) ||
            this.ContainedSpec.Equals(obj as IBuildingSpecification<TProduct>);

    }
}