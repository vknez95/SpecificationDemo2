namespace SpecificationDemo.Interfaces
{
    public interface IUser
    {
        void SetIdentity(IUserIdentity identity);
        bool CanAcceptIdentity(IUserIdentity identity);
        IContactInfo PrimaryContact { get; }
    }
}
