using System.Diagnostics.Contracts;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Builders.Person.Interfaces
{
    public interface IContactHolder
    {
        [Pure]
        bool Contains(IContactInfo contact);
    }
}