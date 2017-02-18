using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Models
{
    public class MacAddress: IUserIdentity
    {
        public string NicPart { get; set; }
    }
}
