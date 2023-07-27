using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.InputModels;

namespace simple_record.tests
{
    [TestClass]
    public class CreateAddressPersonInputModelTest
    {
        [TestMethod]
        public void ToEntity_ShouldConvertToAddressEntity()
        {
            // Arrange
            var inputModel = new CreateAddressPersonInputModel
            {
                Type = AddressType.Commercial,
                Street = "Rua Teste",
                Number = "123",
                Complement = "Apto 4",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345-678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            // Act
            var addressEntity = inputModel.ToEntity();

            // Assert
            Assert.IsNotNull(addressEntity);
            Assert.AreEqual(AddressType.Commercial, addressEntity.Type);
            Assert.AreEqual("Rua Teste", addressEntity.Street);
            Assert.AreEqual("123", addressEntity.Number);
            Assert.AreEqual("Apto 4", addressEntity.Complement);
            Assert.AreEqual("Bairro Teste", addressEntity.Neighborhood);
            Assert.AreEqual("12345-678", addressEntity.ZipCode);
            Assert.AreEqual("Cidade Teste", addressEntity.City);
            Assert.AreEqual("Estado Teste", addressEntity.State);
        }

        [TestMethod]
        public void FromEntityToModel_ShouldConvertToPersonAddressModel()
        {
            // Arrange
            var addressEntity = new Address(
                AddressType.Residential,
                "Av. Principal",
                "789",
                "Centro",
                "54321-987",
                "Cidade Nova",
                "Estado Novo",
                null
            );

            var inputModel = new CreateAddressPersonInputModel
            {
                PersonId = Guid.NewGuid(),
                Type = addressEntity.Type,
                Street = addressEntity.Street,
                Number = addressEntity.Number,
                Complement = addressEntity.Complement,
                Neighborhood = addressEntity.Neighborhood,
                ZipCode = addressEntity.ZipCode,
                City = addressEntity.City,
                State = addressEntity.State
            };

            // Act
            var addressModel = inputModel.FromEntityToModel();

            // Assert
            Assert.IsNotNull(addressModel);
            Assert.AreEqual(inputModel.PersonId, addressModel.PersonId);
            Assert.AreEqual(AddressType.Residential, addressModel.Type);
            Assert.AreEqual("Av. Principal", addressModel.Street);
            Assert.AreEqual("789", addressModel.Number);
            Assert.AreEqual(null, addressModel.Complement);
            Assert.AreEqual("54321-987", addressModel.ZipCode);
            Assert.AreEqual("Cidade Nova", addressModel.City);
            Assert.AreEqual("Estado Novo", addressModel.State);
        }
    }
}
