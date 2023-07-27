using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using System.Collections.Generic;

namespace SimpleRecord.Tests
{
    [TestClass]
    public class LegalPersonTests
    {
        [TestMethod]
        public void LegalPerson_WithValidData_ShouldBeValid()
        {
            // Arrange
            string corporateName = "Company Inc.";
            string contact = "(11) 91234-5678";
            PersonTypes type = PersonTypes.Legal;
            string email = "john.doe@example.com";
            string cnpj = "00.275.181/0001-69";

            var addresses = new List<Address>
            {
                new Address(AddressType.Commercial, "123 Main St", "Apt 1", "Downtown", "12345-678", "New York", "NY", null)
            };

            // Act
            var legalPerson = new LegalPerson(corporateName, contact, type, email, cnpj, addresses);

            // Assert
            Assert.IsTrue(legalPerson.Valid);
            Assert.AreEqual(0, legalPerson.Notifications.Count);
        }

        [TestMethod]
        public void LegalPerson_WithInvalidCnpj_ShouldBeInvalid()
        {
            // Arrange
            string corporateName = "Company Inc.";
            string contact = "(11) 91234-5678";
            PersonTypes type = PersonTypes.Legal;
            string email = "john.doe@example.com";
            string cnpj = ""; // Invalid CNPJ

            var addresses = new List<Address>
            {
                new Address(AddressType.Commercial, "123 Main St", "Apt 1", "Downtown", "12345-678", "New York", "NY", null)
            };

            // Act
            var legalPerson = new LegalPerson(corporateName, contact, type, email, cnpj, addresses);

            // Assert
            Assert.IsFalse(legalPerson.Valid);
            Assert.AreEqual(1, legalPerson.Notifications.Count);
        }

        [TestMethod]
        public void LegalPerson_WithEmptyCorporateName_ShouldBeInvalid()
        {
            // Arrange
            string corporateName = ""; // Empty corporate name
            string contact = "(11) 91234-5678";
            PersonTypes type = PersonTypes.Legal;
            string email = "john.doe@example.com";
            string cnpj = "00.275.181/0001-69";

            var addresses = new List<Address>
            {
                new Address(AddressType.Residential, "123 Main St", "Apt 1", "Downtown", "12345-678", "New York", "NY", null)
            };

            // Act
            var legalPerson = new LegalPerson(corporateName, contact, type, email, cnpj, addresses);

            // Assert
            Assert.IsFalse(legalPerson.Valid);
            Assert.AreEqual(1, legalPerson.Notifications.Count);
        }

        [TestMethod]
        public void LegalPerson_UpdateWithValidData_ShouldBeValid()
        {
            // Arrange
            string corporateName = "Company Inc.";
            string contact = "(11) 91234-5678";
            PersonTypes type = PersonTypes.Legal;
            string email = "john.doe@example.com";
            string cnpj = "00.275.181/0001-69";

            var addresses = new List<Address>
            {
                new Address(AddressType.Residential, "123 Main St", "Apt 1", "Downtown", "12345-678", "New York", "NY", null)
            };

            var legalPerson = new LegalPerson(corporateName, contact, type, email, cnpj, addresses);

            // Act
            legalPerson.UpdatePhysicalPerson("New Company Inc.", "Jane Smith", "jane.smith@example.com");
            Console.WriteLine(legalPerson.Notifications);
            // Assert
            Assert.IsTrue(legalPerson.Valid);
            Assert.AreEqual("New Company Inc.", legalPerson.CorporateName);
            Assert.AreEqual("Jane Smith", legalPerson.Contact);
            Assert.AreEqual("jane.smith@example.com", legalPerson.Email);
        }
    }
}
