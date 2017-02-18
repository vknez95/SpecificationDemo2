using System.Collections.Generic;
using SpecificationDemo.Interfaces;
using System.Linq;

namespace SpecificationDemo.Models
{
    public class LegalEntity
    {

        public string CompanyName { get; internal set; }
        public EmailAddress EmailAddress { get; internal set; }
        public PhoneNumber PhoneNumber { get; internal set; }
        public IEnumerable<IContactInfo> OtherContacts { get; internal set; }

        internal LegalEntity() { }

        public override string ToString() =>
            $"{this.CompanyName} {this.EmailAddress} {this.PhoneNumber} [{this.OtherContactsToString()}]";

        private string OtherContactsToString() =>
            string.Join(", ", this.OtherContactsToStringArray());

        private string[] OtherContactsToStringArray() =>
            this.OtherContacts.Select(contact => contact.ToString()).ToArray();
    }
}
