using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Common
{
    public interface IPrimaryContactState
    {
        IPrimaryContactState Set(IContactInfo contact);
        IContactInfo Get();
    }
}
