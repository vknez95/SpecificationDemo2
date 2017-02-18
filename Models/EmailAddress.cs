using System.Globalization;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Models
{
    public class EmailAddress: IContactInfo
    {
        public string Address { get; internal set; }

        internal EmailAddress() { }

        public override int GetHashCode() => this.Address.ToLower().GetHashCode();

        public override bool Equals(object obj)
        {
            EmailAddress email = obj as EmailAddress;

            if (email == null)
                return false;

            return string.Compare(this.Address, email.Address, 
                                  true, CultureInfo.InvariantCulture) == 0;

        }

        public override string ToString() => $"{this.Address}";

    }
}
