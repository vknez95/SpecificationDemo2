using SpecificationDemo.Specifications.EmailAddress;
using SpecificationDemo.Specifications.PhoneNumber;
using SpecificationDemo.Specifications.PhoneNumber.Interfaces;

namespace SpecificationDemo.Specifications.ContactInfo
{
    public static class ContactSpecification
    {
        public static IBuildingSpecification<Models.EmailAddress> ForEmailAddress(string emailAddress) =>
            EmailAddressSpecification.Initialize().WithAddress(emailAddress);

        public static IExpectCountryCode ForPhoneNumber() =>
            PhoneNumberSpecification.Initialize();
    }
}
