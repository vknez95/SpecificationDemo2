using SpecificationDemo.Specifications.Machine;
using SpecificationDemo.Specifications.Machine.Interfaces;
using SpecificationDemo.Specifications.Person;
using SpecificationDemo.Specifications.Person.Interfaces;

namespace SpecificationDemo.Specifications.User
{
    public static class UserSpecification
    {
        public static IExpectName ForPerson() => PersonSpecification.Initialize();
        public static IExpectProducer ForMachine() => MachineSpecification.Initialize();
    }
}
