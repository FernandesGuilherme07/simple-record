using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using System.Collections.Generic;

namespace SimpleRecord.Tests
{
    [TestClass]
    public class PhysicalPersonTests
    {
        [TestMethod]
        public void UpdatePhysicalPerson_ValidData_ShouldUpdateFields()
        {
            // Arrange
            var physicalPerson = new PhysicalPerson(
                name: "John Doe",
                contact: "(11) 91234-5678",
                type: PersonTypes.Physical,
                email: "john@example.com",
                cpf: "123.456.789-09",
                addresses: new List<Address>()
            );

            // Act
            physicalPerson.UpdatePhysicalPerson(
                name: "John Smith",
                contact: "john.smith@example.com",
                email: "john.smith@example.com"
            );

            // Assert
            Assert.AreEqual("John Smith", physicalPerson.Name);
            Assert.AreEqual("john.smith@example.com", physicalPerson.Contact);
            Assert.AreEqual("john.smith@example.com", physicalPerson.Email);
        }

        [TestMethod]
        public void Validate_ValidData_ShouldNotHaveNotifications()
        {
            // Arrange
            var physicalPerson = new PhysicalPerson(
                name: "John Doe",
                contact: "(11) 91234-5678",
                type: PersonTypes.Physical,
                email: "john@example.com",
                cpf: "123.456.789-09",
                addresses: new List<Address>()
            );

            // Act - Validate will be called in the constructor, so no need to call it explicitly.

            // Assert
            Assert.IsTrue(physicalPerson.Valid);
            Assert.AreEqual(0, physicalPerson.Notifications.Count);
        }

        [TestMethod]
        public void Validate_InvalidCpf_ShouldHaveNotification()
        {
            // Arrange
            var physicalPerson = new PhysicalPerson(
                name: "John Doe",
                contact: "(11) 91234-5678",
                type: PersonTypes.Physical,
                email: "john@example.com",
                cpf: "123.456.789-00", // Invalid CPF
                addresses: new List<Address>()
            );

            // Act - Validate will be called in the constructor, so no need to call it explicitly.

            // Assert
            Assert.IsFalse(physicalPerson.Valid);
            Assert.AreEqual(1, physicalPerson.Notifications.Count);
        }

        [TestMethod]
        public void Validate_EmptyName_ShouldHaveNotification()
        {
            // Arrange
            var physicalPerson = new PhysicalPerson(
                name: "", // Empty Name
                contact: "(11) 91234-5678",
                type: PersonTypes.Physical,
                email: "john@example.com",
                cpf: "123.456.789-09",
                addresses: new List<Address>()
            );

            // Act - Validate will be called in the constructor, so no need to call it explicitly.

            // Assert
            Assert.IsFalse(physicalPerson.Valid);
            Assert.AreEqual(1, physicalPerson.Notifications.Count);
        }
    }
}
