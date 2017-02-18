using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Models
{
    public class PhoneNumber : IContactInfo
    {

        public int CountryCode { get; internal set; }
        public int AreaCode { get; internal set; }
        public int Number { get; internal set; }

        internal PhoneNumber() { }

        public override int GetHashCode() =>
            this.CountryCode.GetHashCode() ^
            this.AreaCode.GetHashCode() ^
            this.Number.GetHashCode();

        public override bool Equals(object obj)
        {
            PhoneNumber other = obj as PhoneNumber;
            return
                other != null && other.CountryCode == this.CountryCode &&
                other.AreaCode == this.AreaCode && other.Number == this.Number;
        }

        public override string ToString() => $"+{this.CountryCode}({this.AreaCode}){this.Number}";

    }
}
