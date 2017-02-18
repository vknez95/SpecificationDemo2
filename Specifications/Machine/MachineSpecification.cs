using System;
using SpecificationDemo.Specifications.Machine.Interfaces;

namespace SpecificationDemo.Specifications.Machine
{
    public class MachineSpecification:
        IExpectProducer, IExpectModel, IExpectOwner,
        IBuildingSpecification<Models.Machine>
    {
        private IBuildingSpecification<Models.Producer> ProducerSpec { get; set; }
        private string Model { get; set; }
        private IBuildingSpecification<Models.LegalEntity> OwnerSpec { get; set; }

        private MachineSpecification() { }

        public static IExpectProducer Initialize() => new MachineSpecification();

        public IExpectModel ProducedBy(IBuildingSpecification<Models.Producer> producerSpec)
        {
            if (producerSpec == null)
                throw new ArgumentNullException();

            return new MachineSpecification()
            {
                ProducerSpec = producerSpec
            };
        }

        public IExpectOwner WithModel(string model)
        {
            if (string.IsNullOrEmpty(model))
                throw new ArgumentException();

            return new MachineSpecification()
            {
                ProducerSpec = this.ProducerSpec,
                Model = model
            };
        }

        public IBuildingSpecification<Models.Machine> OwnedBy(IBuildingSpecification<Models.LegalEntity> ownerSpec)
        {
            if (ownerSpec == null)
                throw new ArgumentNullException();

            return new MachineSpecification()
            {
                ProducerSpec = this.ProducerSpec,
                Model = this.Model,
                OwnerSpec = ownerSpec
            };
        }

        public Models.Machine Build() =>
            new Models.Machine()
            {
                Producer = this.ProducerSpec.Build(),
                Model = this.Model,
                Owner = this.OwnerSpec.Build()
            };

        public bool Equals(IBuildingSpecification<Models.Machine> other) =>
            this.Equals(other as MachineSpecification);

        private bool Equals(MachineSpecification other) =>
            other != null &&
            this.ProducerSpec.SafeEquals(other.ProducerSpec) &&
            this.Model == other.Model &&
            this.OwnerSpec.SafeEquals(other.OwnerSpec);
    }
}
