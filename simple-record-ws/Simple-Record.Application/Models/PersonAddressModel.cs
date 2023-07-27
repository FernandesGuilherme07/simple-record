using System.Text.Json.Serialization;
using simple_record.core.entities;
using simple_record.core.enums;

namespace simple_record.service.Models
{
    public class PersonAddressModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public AddressType Type { get; set; }
        public string Street { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Address ToAddress()
        {
            return new Address(
                Type,
                Street,
                Number,
                Neighborhood,
                ZipCode,
                City,
                State,
                Complement
            );
        }

        public string FullAddress
        {
            get
            {
                // Inicializa uma variável para armazenar o endereço completo
                string fullAddress = Street;

                // Adiciona o número ao endereço completo, se estiver disponível
                if (!string.IsNullOrEmpty(Number))
                    fullAddress += ", " + Number;

                // Adiciona o complemento ao endereço completo, se estiver disponível
                if (!string.IsNullOrEmpty(Complement))
                    fullAddress += ", " + Complement;

                // Adiciona o bairro ao endereço completo
                fullAddress += ", " + Neighborhood;

                // Adiciona o CEP ao endereço completo
                fullAddress += ", " + ZipCode;

                // Adiciona a cidade ao endereço completo
                fullAddress += ", " + City;

                // Adiciona o estado ao endereço completo
                fullAddress += ", " + State;

                return fullAddress;
            }
        }
    }
}
