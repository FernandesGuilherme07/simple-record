using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;

namespace SimpleRecord.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void Address_WithValidData_ShouldBeValid()
        {
            // Arrange
            var address = new Address(
                AddressType.Residential,
                "Example Street",
                "123",
                "Example Neighborhood",
                "12345678",
                "Example City",
                "Example State",
                ""
            );

            // Assert
            Assert.IsTrue(address.Valid);
            Assert.AreEqual(0, address.Notifications.Count);
        }

        [TestMethod]
        public void Address_WithEmptyStreet_ShouldBeInvalid()
        {
            // Arrange
            var address = new Address(
                AddressType.Commercial,
                "",
                "123",
                "Example Neighborhood",
                "12345678",
                "Example City",
                "Example State",
                ""
            );

            // Assert
            Assert.IsFalse(address.Valid);
            Assert.AreEqual(1, address.Notifications.Count);
        }

        // Add more test methods to cover other validation scenarios...
    }
}
