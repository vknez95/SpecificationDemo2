namespace SpecificationDemo.Specifications.LegalEntity.Interfaces
{
    public interface IExpectCompanyName
    {
        IExpectEmailAddress WithCompanyName(string companyName);
    }
}