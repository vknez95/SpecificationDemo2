using System;
using SpecificationDemo.Interfaces;
using SpecificationDemo.Models;
using SpecificationDemo.Specifications;
using SpecificationDemo.Specifications.ContactInfo;
using SpecificationDemo.Specifications.Person.Interfaces;
using SpecificationDemo.Specifications.User;

namespace SpecificationDemo
{
    class Program
    {
        class Cat
        {
            // public static implicit operator Cat(Dog dog) =>
            //     new Cat();
        }

        class Dog
        {
            // public static explicit operator Cat(Dog dog) =>
            //     new Cat();
            // public Cat AsCat() => new Cat();
        }

        class WrappedDog : Cat
        {
            private Dog dog;

            public WrappedDog(Dog dog)
            {
                this.dog = dog;
            }
        }

        class Mouse
        {
            // public static explicit operator Cat(Dog dog) =>
            //     new Cat();
        }

        static void Main(string[] args)
        {
            // Cat cat = new Dog();
            // Cat cat = (Cat)new Dog();
            // Cat cat = new Dog().AsCat();
            Cat cat = new WrappedDog(new Dog());


            IExpectAlternateContact spec =
                UserSpecification
                    .ForPerson()
                    .WithName("Max")
                    .WithSurname("Planck")
                    .WithPrimaryContact(
                        ContactSpecification.ForEmailAddress("max.planck@my-institute.com"));

            IBuildingSpecification<EmailAddress> contact =
                ContactSpecification.ForEmailAddress("max@home-of-plancks.com");

            if (!spec.CanAdd(contact))
            {
                Console.WriteLine("Cannot add desired contact...");
            }
            else
            {
                spec = spec.WithAlternateContact(contact);
                IUser user = spec.AndNoMoreContacts().Build();
                Console.WriteLine(user);
            }

            Console.ReadLine();
        }
    }
}
