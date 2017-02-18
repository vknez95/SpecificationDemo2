using System;
using System.Collections.Generic;
using SpecificationDemo.Factories.Interfaces;
using SpecificationDemo.Interfaces;
using SpecificationDemo.Models;

namespace SpecificationDemo.Factories.Machine
{
    public class MachineFactory: IUserFactory
    {
        private Dictionary<string, Producer> NameToProducer { get; }

        public MachineFactory(Dictionary<string, Producer> nameToProducer)
        {
            if (nameToProducer == null)
                throw new ArgumentNullException();
            this.NameToProducer = nameToProducer;
        }

        private Producer GetProducer(string name)
        {
            Producer producer;
            if (!this.NameToProducer.TryGetValue(name, out producer))
                throw new ArgumentException();
            return producer;
        }

        public IUser CreateUser(string name1, string name2)
        {
            Producer producer = GetProducer(name1);
            LegalEntity owner =
                new LegalEntity()
                {
                    CompanyName =
                        "Big Co.",
                    EmailAddress = new EmailAddress() { Address = "big@co" },
                    PhoneNumber = new PhoneNumber() { CountryCode = 1, AreaCode = 2, Number = 3 }
                };

            return new Models.Machine()
            {
                Producer = producer,
                Model = name2,
                Owner =owner
            };

        }

        public IUserIdentity CreateIdentity()
        {
            return new MacAddress();
        }
    }
}
