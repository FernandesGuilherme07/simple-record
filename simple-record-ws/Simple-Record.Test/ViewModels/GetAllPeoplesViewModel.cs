using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.Models;
using simple_record.service.ViewModels;
using System;
using System.Collections.Generic;

namespace simple_record.tests
{
    [TestClass]
    public class GetAllPeoplesViewModelTests
    {
        [TestMethod]
        public void ToListFromModel_ShouldConvertPersonModelsToListOfViewModels()
        {
            // Arrange
            var residentialAddress1 = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Residential,
                Street = "Rua Residencial 1",
                Number = "123",
                Complement = "Apto 1",
                Neighborhood = "Bairro Residencial",
                ZipCode = "12345678",
                City = "Cidade Residencial",
                State = "Estado Residencial"
            };

            var commercialAddress1 = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Commercial,
                Street = "Rua Comercial 1",
                Number = "456",
                Complement = "Sala 1",
                Neighborhood = "Bairro Comercial",
                ZipCode = "87654321",
                City = "Cidade Comercial",
                State = "Estado Comercial"
            };

            var personModel1 = new PersonModel
            {
                Id = Guid.NewGuid(),
                Name = "Pessoa 1",
                Document = "12345678901",
                Type = PersonTypes.Legal,
                Contact = "contato1@teste.com",
                Email = "teste1@teste.com",
                Addresses = new List<PersonAddressModel> { residentialAddress1, commercialAddress1 }
            };

            var residentialAddress2 = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Residential,
                Street = "Rua Residencial 2",
                Number = "456",
                Complement = "Apto 2",
                Neighborhood = "Bairro Residencial",
                ZipCode = "98765432",
                City = "Cidade Residencial",
                State = "Estado Residencial"
            };

            var commercialAddress2 = new PersonAddressModel
            {
                Id = Guid.NewGuid(),
                Type = AddressType.Commercial,
                Street = "Rua Comercial 2",
                Number = "789",
                Complement = "Sala 2",
                Neighborhood = "Bairro Comercial",
                ZipCode = "23456789",
                City = "Cidade Comercial",
                State = "Estado Comercial"
            };

            var personModel2 = new PersonModel
            {
                Id = Guid.NewGuid(),
                Name = "Pessoa 2",
                Document = "98765432109",
                Type = PersonTypes.Physical,
                Contact = "contato2@teste.com",
                Email = "teste2@teste.com",
                Addresses = new List<PersonAddressModel> { residentialAddress2, commercialAddress2 }
            };

            var peopleModels = new List<PersonModel> { personModel1, personModel2 };
            var viewModel = new GetAllPeoplesViewModel();

            // Act
            var resultList = viewModel.ToListFromModel(peopleModels);

            // Assert
            Assert.IsNotNull(resultList);
            Assert.AreEqual(2, resultList.Count);

            var viewModel1 = resultList[0];
            Assert.AreEqual(personModel1.Id, viewModel1.Id);
            Assert.AreEqual(personModel1.Name, viewModel1.Name);
            Assert.AreEqual(personModel1.Document, viewModel1.Document);
            Assert.AreEqual(personModel1.Type, viewModel1.Type);
            Assert.AreEqual(personModel1.Contact, viewModel1.Contact);
            Assert.AreEqual(personModel1.Email, viewModel1.Email);
            Assert.IsNotNull(viewModel1.AddressesResidentials);
            Assert.AreEqual(1, viewModel1.AddressesResidentials.Count);
            Assert.AreEqual(residentialAddress1.Street, viewModel1.AddressesResidentials[0].Street);
            Assert.AreEqual(residentialAddress1.Number, viewModel1.AddressesResidentials[0].Number);
            Assert.AreEqual(residentialAddress1.Complement, viewModel1.AddressesResidentials[0].Complement);
            Assert.AreEqual(residentialAddress1.Neighborhood, viewModel1.AddressesResidentials[0].Neighborhood);
            Assert.AreEqual(residentialAddress1.ZipCode, viewModel1.AddressesResidentials[0].ZipCode);
            Assert.AreEqual(residentialAddress1.City, viewModel1.AddressesResidentials[0].City);
            Assert.AreEqual(residentialAddress1.State, viewModel1.AddressesResidentials[0].State);

            Assert.IsNotNull(viewModel1.AddressesCommercials);
            Assert.AreEqual(1, viewModel1.AddressesCommercials.Count);
            Assert.AreEqual(commercialAddress1.Street, viewModel1.AddressesCommercials[0].Street);
            Assert.AreEqual(commercialAddress1.Number, viewModel1.AddressesCommercials[0].Number);
            Assert.AreEqual(commercialAddress1.Complement, viewModel1.AddressesCommercials[0].Complement);
            Assert.AreEqual(commercialAddress1.Neighborhood, viewModel1.AddressesCommercials[0].Neighborhood);
            Assert.AreEqual(commercialAddress1.ZipCode, viewModel1.AddressesCommercials[0].ZipCode);
            Assert.AreEqual(commercialAddress1.City, viewModel1.AddressesCommercials[0].City);
            Assert.AreEqual(commercialAddress1.State, viewModel1.AddressesCommercials[0].State);

            var viewModel2 = resultList[1];
            Assert.AreEqual(personModel2.Id, viewModel2.Id);
            Assert.AreEqual(personModel2.Name, viewModel2.Name);
            Assert.AreEqual(personModel2.Document, viewModel2.Document);
            Assert.AreEqual(personModel2.Type, viewModel2.Type);
            Assert.AreEqual(personModel2.Contact, viewModel2.Contact);
            Assert.AreEqual(personModel2.Email, viewModel2.Email);
            Assert.IsNotNull(viewModel2.AddressesResidentials);
            Assert.AreEqual(1, viewModel2.AddressesResidentials.Count);
            Assert.AreEqual(residentialAddress2.Street, viewModel2.AddressesResidentials[0].Street);
            Assert.AreEqual(residentialAddress2.Number, viewModel2.AddressesResidentials[0].Number);
            Assert.AreEqual(residentialAddress2.Complement, viewModel2.AddressesResidentials[0].Complement);
            Assert.AreEqual(residentialAddress2.Neighborhood, viewModel2.AddressesResidentials[0].Neighborhood);
            Assert.AreEqual(residentialAddress2.ZipCode, viewModel2.AddressesResidentials[0].ZipCode);
            Assert.AreEqual(residentialAddress2.City, viewModel2.AddressesResidentials[0].City);
            Assert.AreEqual(residentialAddress2.State, viewModel2.AddressesResidentials[0].State);

            Assert.IsNotNull(viewModel2.AddressesCommercials);
            Assert.AreEqual(1, viewModel2.AddressesCommercials.Count);
            Assert.AreEqual(commercialAddress2.Street, viewModel2.AddressesCommercials[0].Street);
            Assert.AreEqual(commercialAddress2.Number, viewModel2.AddressesCommercials[0].Number);
            Assert.AreEqual(commercialAddress2.Complement, viewModel2.AddressesCommercials[0].Complement);
            Assert.AreEqual(commercialAddress2.Neighborhood, viewModel2.AddressesCommercials[0].Neighborhood);
            Assert.AreEqual(commercialAddress2.ZipCode, viewModel2.AddressesCommercials[0].ZipCode);
            Assert.AreEqual(commercialAddress2.City, viewModel2.AddressesCommercials[0].City);
            Assert.AreEqual(commercialAddress2.State, viewModel2.AddressesCommercials[0].State);
        }
    }
}
