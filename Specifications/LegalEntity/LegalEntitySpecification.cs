using SpecificationDemo.Specifications;
using System;
using System.Collections.Generic;
using SpecificationDemo.Interfaces;
using System.Linq;
using SpecificationDemo.Specifications.LegalEntity.Interfaces;

namespace SpecificationDemo.Specifications.LegalEntity
{
    public class LegalEntitySpecification:
        IExpectCompanyName, IExpectEmailAddress,
        IExpectPhoneNumber, IExpectOtherContact,
        IBuildingSpecification<Models.LegalEntity>
    {
        private string CompanyName { get; set; }
        private IBuildingSpecification<Models.EmailAddress> EmailAddressSpec { get; set; }
        private IBuildingSpecification<Models.PhoneNumber> PhoneNumberSpec { get; set; }

        private IList<IBuildingSpecification<IContactInfo>> OtherContactSpecs { get; set; }
            = new List<IBuildingSpecification<IContactInfo>>();

        private LegalEntitySpecification() { }

        public static IExpectCompanyName Initialize() => new LegalEntitySpecification();

        public IExpectEmailAddress WithCompanyName(string companyName)
        {
            if (string.IsNullOrEmpty(companyName))
                throw new ArgumentException();

            return new LegalEntitySpecification()
            {
                CompanyName = companyName
            };
        }

        public IExpectPhoneNumber WithEmailAddress(IBuildingSpecification<Models.EmailAddress> emailSpec)
        {
            if (emailSpec == null)
                throw new ArgumentNullException();

            return new LegalEntitySpecification()
            {
                CompanyName = this.CompanyName,
                EmailAddressSpec = emailSpec
            };
        }

        public IExpectOtherContact WithPhoneNumber(IBuildingSpecification<Models.PhoneNumber> phoneSpec)
        {
            if (phoneSpec == null)
                throw new ArgumentNullException();

            return new LegalEntitySpecification()
            {
                CompanyName = this.CompanyName,
                EmailAddressSpec = this.EmailAddressSpec,
                PhoneNumberSpec = phoneSpec
            };
        }

        public IExpectOtherContact WithOtherContact(IBuildingSpecification<IContactInfo> contactSpec)
        {
            if (contactSpec == null)
                throw new ArgumentNullException();

            return new LegalEntitySpecification()
            {
                CompanyName = this.CompanyName,
                EmailAddressSpec = this.EmailAddressSpec,
                PhoneNumberSpec = this.PhoneNumberSpec,
                OtherContactSpecs = new List<IBuildingSpecification<IContactInfo>>(this.OtherContactSpecs) { contactSpec }
            };
        }

        public IBuildingSpecification<Models.LegalEntity> AndNoMoreContacts() => this;

        public Models.LegalEntity Build() =>
            new Models.LegalEntity()
            {
                CompanyName = this.CompanyName,
                EmailAddress = this.EmailAddressSpec.Build(),
                PhoneNumber = this.PhoneNumberSpec.Build(),
                OtherContacts = this.OtherContactSpecs.Select(spec => spec.Build()).ToList()
            };

        public bool Equals(IBuildingSpecification<Models.LegalEntity> other) =>
            this.Equals(other as LegalEntitySpecification);

        private bool Equals(LegalEntitySpecification other) =>
            other != null &&
            this.CompanyName == other.CompanyName &&
            this.EmailAddressSpec.SafeEquals(other.EmailAddressSpec) &&
            this.PhoneNumberSpec.SafeEquals(other.PhoneNumberSpec) &&
            this.OtherContactSpecs.SequenceEqual(other.OtherContactSpecs);
    }
}
