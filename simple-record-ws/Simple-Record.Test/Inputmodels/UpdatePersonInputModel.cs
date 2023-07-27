using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.InputModels;
using simple_record.service.Models;

namespace simple_record.tests
{
    [TestClass]
    public class UpdatePersonInputModelTests
    {
        [TestMethod]
        public void ToEntityLegalPerson_ShouldConvertToLegalPersonEntity()
        {
            // Arrange
            var addressModel = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Commercial,
                Street = "Rua Teste",
                Number = "123",
                Complement = "Apto 1",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            var inputModel = new UpdatePersonInputModel(
                Guid.NewGuid(),
                "Nome Teste",
                "65.750.985/0001-18",
                PersonTypes.Legal,
                "contato@teste.com",
                "teste@teste.com",
                new List<PersonAddressModel> { addressModel }
            );

            // Act
            var legalPersonEntity = inputModel.ToEntityLegalPerson();

            // Assert
            Assert.IsNotNull(legalPersonEntity);
            Assert.AreEqual("Nome Teste", legalPersonEntity.CorporateName);
            Assert.AreEqual("65.750.985/0001-18", legalPersonEntity.CNPJ);
            Assert.AreEqual(PersonTypes.Legal, legalPersonEntity.Type);
            Assert.AreEqual("contato@teste.com", legalPersonEntity.Contact);
            Assert.AreEqual("teste@teste.com", legalPersonEntity.Email);
            Assert.IsNotNull(legalPersonEntity.Addresses);
            Assert.AreEqual(1, legalPersonEntity.Addresses.Count);
        }

        [TestMethod]
        public void ToEntityPhysicalPerson_ShouldConvertToPhysicalPersonEntity()
        {
            // Arrange
            var addressModel = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Residential,
                Street = "Rua Teste",
                Number = "123",
                Complement = "Apto 1",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            var inputModel = new UpdatePersonInputModel(
                Guid.NewGuid(),
                "Nome Teste",
                "651.272.240-03",
                PersonTypes.Physical,
                "contato@teste.com",
                "teste@teste.com",
                new List<PersonAddressModel> { addressModel }
            );

            // Act
            var physicalPersonEntity = inputModel.ToEntityPhysicalPerson();

            // Assert
            Assert.IsNotNull(physicalPersonEntity);
            Assert.AreEqual("Nome Teste", physicalPersonEntity.Name);
            Assert.AreEqual("651.272.240-03", physicalPersonEntity.CPF);
            Assert.AreEqual(PersonTypes.Physical, physicalPersonEntity.Type);
            Assert.AreEqual("contato@teste.com", physicalPersonEntity.Contact);
            Assert.AreEqual("teste@teste.com", physicalPersonEntity.Email);
            Assert.IsNotNull(physicalPersonEntity.Addresses);
            Assert.AreEqual(1, physicalPersonEntity.Addresses.Count);
        }

        [TestMethod]
        public void Validate_ShouldHaveNotificationsWhenNameAndContactAreEmpty()
        {
            // Arrange
            var inputModel = new UpdatePersonInputModel(
                Guid.NewGuid(),
                "",
                "651.272.240-03",
                PersonTypes.Legal,
                "",
                "teste@teste.com",
                new List<PersonAddressModel>()
            );

            // Act
            inputModel.Validate();

            // Assert
            Assert.IsTrue(inputModel.Invalid);
            Assert.AreEqual(2, inputModel.Notifications.Count);
            Assert.IsTrue(inputModel.Notifications.Any(n => n.Property == "Name" && n.Message == "Name cannot be empty."));
            Assert.IsTrue(inputModel.Notifications.Any(n => n.Property == "Contact" && n.Message == "Contact cannot be empty."));
        }

        [TestMethod]
        public void Validate_ShouldBeValidWhenNameAndContactAreNotEmpty()
        {
            // Arrange
            var inputModel = new UpdatePersonInputModel(
                Guid.NewGuid(),
                "Nome Teste",
                "651.272.240-03",
                PersonTypes.Legal,
                "contato@teste.com",
                "teste@teste.com",
                new List<PersonAddressModel>()
            );

            // Act
            inputModel.Validate();

            // Assert
            Assert.IsTrue(inputModel.Valid);
            Assert.AreEqual(0, inputModel.Notifications.Count);
        }
    }
}
