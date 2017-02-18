using System;

namespace SpecificationDemo.Specifications
{
    public interface IBuildingSpecification<T> : IEquatable<IBuildingSpecification<T>>
    {
        T Build();
    }
}
