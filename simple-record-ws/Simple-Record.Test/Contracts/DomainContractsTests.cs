
using simple_record.core;

namespace SimpleRecord.Tests
{
    [TestClass]
    public class DomainContractTests
    {
        [TestMethod]
        public void IsCnpjValid_ValidCnpj_ReturnsTrue()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string validCnpj = "00.275.181/0001-69";

            // Act
            domainContracts.IsCnpjValid(validCnpj, "Cnpj", "Invalid CNPJ");

            // Assert
            Assert.IsTrue(domainContracts.Valid); // Verifica se a validação passou
            Assert.AreEqual(0, domainContracts.Notifications.Count); // Verifica se não há notificações de erro
        }

        [TestMethod]
        public void IsCnpjValid_InvalidCnpj_ReturnsFalse()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string invalidCnpj = "12345678000190"; // CNPJ sem pontuações

            // Act
            domainContracts.IsCnpjValid(invalidCnpj, "Cnpj", "Invalid CNPJ");

            // Assert
            Assert.IsFalse(domainContracts.Valid); // Verifica se a validação falhou
            Assert.AreEqual(1, domainContracts.Notifications.Count); // Verifica se há uma notificação de erro
        }

        [TestMethod]
        public void IsCnpjValid_EmptyCnpj_ReturnsFalse()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string emptyCnpj = "";

            // Act
            domainContracts.IsCnpjValid(emptyCnpj, "Cnpj", "Invalid CNPJ");

            // Assert
            Assert.IsFalse(domainContracts.Valid); // Verifica se a validação falhou
            Assert.AreEqual(1, domainContracts.Notifications.Count); // Verifica se há uma notificação de erro
        }

        [TestMethod]
        public void IsCpfValid_ValidCpf_ReturnsTrue()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string validCpf = "123.456.789-09";

            // Act
            domainContracts.IsCpfValid(validCpf, "Cpf", "Invalid CPF");

            // Assert
            Assert.AreEqual(0, domainContracts.Notifications.Count);
        }

        [TestMethod]
        public void IsCpfValid_EmptyCpf_ReturnsFalse()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string emptyCpf = "";

            // Act
            domainContracts.IsCpfValid(emptyCpf, "Cpf", "Invalid CPF");

            // Assert
            Assert.IsFalse(domainContracts.Valid);
        }

        [TestMethod]
        public void IsCpfValid_CpfWithLetters_ReturnsFalse()
        {
            // Arrange
            var domainContracts = new DomainContract();
            string cpfWithLetters = "123.ABC.789-09";

            // Act
            domainContracts.IsCpfValid(cpfWithLetters, "Cpf", "Invalid CPF");

            // Assert
            Assert.IsFalse(domainContracts.Valid);
        }

        [TestMethod]
        public void IsMobileNumberValid_ValidMobileNumber_ReturnsTrue()
        {
            // Arrange
            var domainContract = new DomainContract();
            string validMobileNumber = "(11) 91234-5678";

            // Act
            var result = domainContract.IsMobileNumberValid(validMobileNumber, "MobileNumber", "Invalid mobile number");

            // Assert
            Assert.IsTrue(result.Valid);
        }

        [TestMethod]
        public void IsMobileNumberValid_InvalidMobileNumber_ReturnsFalse()
        {
            // Arrange
            var domainContract = new DomainContract();
            string invalidMobileNumber = "(11) 12345-6789"; // Missing "9" after the DDD

            // Act
            var result = domainContract.IsMobileNumberValid(invalidMobileNumber, "MobileNumber", "Invalid mobile number");

            // Assert
            Assert.IsFalse(result.Valid);
        }

        [TestMethod]
        public void IsMobileNumberValid_NonNumericMobileNumber_ReturnsFalse()
        {
            // Arrange
            var domainContract = new DomainContract();
            string nonNumericMobileNumber = "(11) ABCDE-FGHI"; // Non-numeric characters

            // Act
            var result = domainContract.IsMobileNumberValid(nonNumericMobileNumber, "MobileNumber", "Invalid mobile number");

            // Assert
            Assert.IsFalse(result.Valid);
        }

    }
}
