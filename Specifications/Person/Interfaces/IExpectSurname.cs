namespace SpecificationDemo.Specifications.Person.Interfaces
{
    public interface IExpectSurname
    {
        IExpectPrimaryContact WithSurname(string surname);
    }
}