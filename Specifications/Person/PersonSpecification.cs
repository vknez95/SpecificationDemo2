using System;
using System.Collections.Generic;
using SpecificationDemo.Interfaces;
using System.Linq;
using SpecificationDemo.Specifications.Person.Interfaces;
using SpecificationDemo.Models;

namespace SpecificationDemo.Specifications.Person
{
    public class PersonSpecification :
        IExpectName, IExpectSurname,
        IExpectPrimaryContact, IExpectAlternateContact,
        IBuildingSpecification<Models.Person>
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private IEnumerable<IBuildingSpecification<IContactInfo>> ContactSpecs { get; set; }
        private IBuildingSpecification<IContactInfo> PrimaryContactSpec { get; set; }

        private PersonSpecification() { }

        public static IExpectName Initialize() => new PersonSpecification();

        public IExpectSurname WithName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();

            return new PersonSpecification()
            {
                Name = name
            };
        }

        public IExpectPrimaryContact WithSurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException();

            return new PersonSpecification()
            {
                Name = this.Name,
                Surname = surname
            };
        }

        public IExpectAlternateContact WithPrimaryContact<T>(IBuildingSpecification<T> primaryContactSpec) where T : IContactInfo
        {
            if (primaryContactSpec == null)
                throw new ArgumentNullException();

            // ConvertingSpecification<IContactInfo, T> convertedSpec =
            //     new ConvertingSpecification<IContactInfo, T>(primaryContactSpec);

            var convertedSpec = BuildConvertingSpecification<IContactInfo, T>.From(primaryContactSpec);

            return new PersonSpecification()
            {
                Name = this.Name,
                Surname = this.Surname,
                ContactSpecs = new[] { convertedSpec },
                PrimaryContactSpec = convertedSpec
            };
        }

        public IExpectAlternateContact WithAlternateContact<T>(IBuildingSpecification<T> contactSpec) where T : IContactInfo
        {
            if (!this.CanAdd(contactSpec))
                throw new ArgumentException();

            ConvertingSpecification<IContactInfo, T> convertedSpec =
                new ConvertingSpecification<IContactInfo, T>(contactSpec);

            return new PersonSpecification()
            {
                Name = this.Name,
                Surname = this.Surname,
                ContactSpecs = new List<IBuildingSpecification<IContactInfo>>(this.ContactSpecs) { convertedSpec },
                PrimaryContactSpec = this.PrimaryContactSpec
            };
        }

        public bool CanAdd<T>(IBuildingSpecification<T> contactSpec) where T : IContactInfo =>
            contactSpec != null &&
            CanAdd(new ConvertingSpecification<IContactInfo, T>(contactSpec));

        private bool CanAdd(IBuildingSpecification<IContactInfo> contactSpec) =>
            !this.ContactSpecs.Any(spec => spec.Equals(contactSpec));

        public IBuildingSpecification<Models.Person> AndNoMoreContacts() => this;

        public Models.Person Build() =>
            new Models.Person()
            {
                Name = this.Name,
                Surname = this.Surname,
                PrimaryContact = this.PrimaryContactSpec.Build(),
                ContactsList = this.ContactSpecs.Select(spec => spec.Build()).ToList()
            };

        public bool Equals(IBuildingSpecification<Models.Person> other) =>
            this.Equals(other as PersonSpecification);

        private bool Equals(PersonSpecification other) =>
            other != null &&
            this.Name == other.Name &&
            this.Surname == other.Surname &&
            this.PrimaryContactSpec.SafeEquals(other.PrimaryContactSpec) &&
            this.ContactSpecs.SequenceEqual(other.ContactSpecs);
    }
}
