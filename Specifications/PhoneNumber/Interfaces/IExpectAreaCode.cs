namespace SpecificationDemo.Specifications.PhoneNumber.Interfaces
{
    public interface IExpectAreaCode
    {
        IExpectNumber WithAreaCode(int areaCode);
    }
}