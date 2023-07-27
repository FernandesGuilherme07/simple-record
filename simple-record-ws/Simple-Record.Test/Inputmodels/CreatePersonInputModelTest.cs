using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.InputModels;

namespace simple_record.tests
{
    [TestClass]
    public class CreatePersonInputModelTests
    {
        [TestMethod]
        public void ToEntityLegalPerson_ShouldConvertToLegalPersonEntity()
        {
            // Arrange
            var inputModel = new CreatePersonInputModel(
                "Nome Teste",
                "65.750.985/0001-18",
                PersonTypes.Legal,
                "contato@teste.com",
                "teste@teste.com",
                new List<Address>()
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
            Assert.AreEqual(0, legalPersonEntity.Addresses.Count);
        }

        [TestMethod]
        public void ToEntityPhysicalPerson_ShouldConvertToPhysicalPersonEntity()
        {
            // Arrange
            var inputModel = new CreatePersonInputModel(
                "Nome Teste",
                "651.272.240-03",
                PersonTypes.Physical,
                "contato@teste.com",
                "teste@teste.com",
                new List<Address>()
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
            Assert.AreEqual(0, physicalPersonEntity.Addresses.Count);
        }
    }
}
