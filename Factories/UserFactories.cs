using System;
using SpecificationDemo.Builders.Machine;
using SpecificationDemo.Builders.Person;
using SpecificationDemo.Interfaces;
using SpecificationDemo.Models;

namespace SpecificationDemo.Factories
{
    public static class UserFactories
    {
        public static Func<IUser> PersonFactory =>
            PersonBuilder
                .Person()
                .WithFirstName("Max")
                .WithLastName("Planck")
                .WithPrimaryContact(new EmailAddress() { Address = "max.planck@my-institute.com" })
                .WithSecondaryContact(new EmailAddress() { Address = "max@home-of-plancks.com" })
                .AndNoMoreContacts()
                .Build;

        public static Func<IUser> MachineFactory => CreateMachineFactory(CreateLegalEntity);

        private static Func<IUser> CreateMachineFactory(Func<LegalEntity> ownerFactory) =>
            MachineBuilder
                .Machine()
                .WithProducer(new Producer())
                .WithModel("fast-one")
                .OwnedBy(ownerFactory())
                .Build;

        private static Func<LegalEntity> CreateLegalEntityFactory(
            Func<EmailAddress> emailAddressFactory) =>
                () => new LegalEntity()
                    {
                        CompanyName = "Big Co.",
                        EmailAddress = emailAddressFactory(),
                        PhoneNumber = new PhoneNumber() {CountryCode = 123, AreaCode = 45, Number = 6789}
                    };

        private static Func<LegalEntity> CreateLegalEntity =>
            CreateLegalEntityFactory(() => new EmailAddress() { Address = "big@co" });

    }
}
