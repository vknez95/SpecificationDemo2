namespace SpecificationDemo.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectCountryCode
    {
        IExpectAreaCode WithCountryCode(int countryCode);
    }
}