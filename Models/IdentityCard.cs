using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Models
{
    public class IdentityCard: IUserIdentity
    {
        public string SSN => "imagine one";
    }
}
