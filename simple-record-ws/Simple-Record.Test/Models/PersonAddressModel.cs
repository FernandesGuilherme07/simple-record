using simple_record.service.Models;

namespace simple_record.tests
{
    [TestClass]
    public class PersonAddressModelTests
    {
        [TestMethod]
        public void FullAddress_ShouldReturnCompleteAddress()
        {
            // Arrange
            var addressModel = new PersonAddressModel
            {
                Street = "Rua Teste",
                Number = "123",
                Complement = "Apto 1",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            // Act
            var fullAddress = addressModel.FullAddress;

            // Assert
            var expectedAddress = "Rua Teste, 123, Apto 1, Bairro Teste, 12345678, Cidade Teste, Estado Teste";
            Assert.AreEqual(expectedAddress, fullAddress);
        }

        [TestMethod]
        public void FullAddress_ShouldReturnAddressWithoutComplement()
        {
            // Arrange
            var addressModel = new PersonAddressModel
            {
                Street = "Rua Teste",
                Number = "123",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            // Act
            var fullAddress = addressModel.FullAddress;

            // Assert
            var expectedAddress = "Rua Teste, 123, Bairro Teste, 12345678, Cidade Teste, Estado Teste";
            Assert.AreEqual(expectedAddress, fullAddress);
        }

        [TestMethod]
        public void FullAddress_ShouldReturnAddressWithoutNumberAndComplement()
        {
            // Arrange
            var addressModel = new PersonAddressModel
            {
                Street = "Rua Teste",
                Neighborhood = "Bairro Teste",
                ZipCode = "12345678",
                City = "Cidade Teste",
                State = "Estado Teste"
            };

            // Act
            var fullAddress = addressModel.FullAddress;

            // Assert
            var expectedAddress = "Rua Teste, Bairro Teste, 12345678, Cidade Teste, Estado Teste";
            Assert.AreEqual(expectedAddress, fullAddress);
        }
    }
}
