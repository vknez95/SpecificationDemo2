using System;
using SpecificationDemo.Interfaces;

namespace SpecificationDemo.Models
{
    public class PersonalManager
    {

        private Func<IUser> UserFactory { get; }

        public PersonalManager(Func<IUser> userFactory)
        {
            this.UserFactory = userFactory;
        }

        public void Notify(string message)
        {
            this.Enqueue(this.GetPrimaryContact(), message);
        }

        private IContactInfo GetPrimaryContact()
        {
            return this.UserFactory().PrimaryContact;
        }

        private void Enqueue(IContactInfo contact, string message)
        {
            Console.WriteLine("Sending '{0}' to {1}.", message, contact);
        }
    }
}
