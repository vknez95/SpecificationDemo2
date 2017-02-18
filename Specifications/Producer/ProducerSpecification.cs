using System;

namespace SpecificationDemo.Specifications.Producer
{
    public class ProducerSpecification: IBuildingSpecification<Models.Producer>
    {
        private string Name { get; set; }

        private ProducerSpecification() { }

        public static IBuildingSpecification<Models.Producer> WithName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException();

            return new ProducerSpecification()
            {
                Name = name
            };
        }

        public Models.Producer Build() =>
            new Models.Producer() {Name = this.Name};

        public bool Equals(IBuildingSpecification<Models.Producer> other) =>
            this.Equals(other as ProducerSpecification);

        private bool Equals(ProducerSpecification other) =>
            other != null && other.Name == this.Name;

    }
}
