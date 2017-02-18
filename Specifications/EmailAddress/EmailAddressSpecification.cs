using System;

namespace SpecificationDemo.Specifications.EmailAddress
{
    public class EmailAddressSpecification:
        Interfaces.IExpectAddress, IBuildingSpecification<Models.EmailAddress>
    {

        private string EmailAddress { get; set; }

        private EmailAddressSpecification() { }

        public static Interfaces.IExpectAddress Initialize() => 
            new EmailAddressSpecification();

        public IBuildingSpecification<Models.EmailAddress> WithAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException();
            return new EmailAddressSpecification() {EmailAddress = emailAddress};
        }

        public Models.EmailAddress Build() =>
            new Models.EmailAddress()
            {
                Address = this.EmailAddress
            };

        public bool Equals(IBuildingSpecification<Models.EmailAddress> other) =>
            this.Equals(other as EmailAddressSpecification);

        private bool Equals(EmailAddressSpecification other) =>
            other != null && 
            string.Compare(this.EmailAddress, other.EmailAddress, StringComparison.OrdinalIgnoreCase) == 0;

    }
}
