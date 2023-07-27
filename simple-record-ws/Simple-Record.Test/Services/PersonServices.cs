using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using simple_record.core.entities;
using simple_record.core.enums;
using simple_record.service.InputModels;
using simple_record.service.Models;
using simple_record.service.Repositories;
using simple_record.service.Services;
using simple_record.service.ViewModels;
using System.Runtime.Intrinsics.X86;

namespace simple_record.tests
{
    [TestClass]
    public class PersonServicesTests
    {
        private Mock<IPersonRepository> _repositoryMock;
        private PersonServices _personServices;

        [TestInitialize]
        public void Initialize()
        {
            _repositoryMock = new Mock<IPersonRepository>();
            _personServices = new PersonServices(_repositoryMock.Object);
        }

        [TestMethod]
        public async Task CreatePerson_ValidPerson_ReturnsSuccess()
        {
            var model = new CreatePersonInputModel("John Doe", "651.272.240-03", PersonTypes.Physical, "83993239407", "john.doe@example.com", new List<Address>());

            _repositoryMock.Setup(repo => repo.CreatePersonAsync(It.IsAny<CreatePersonInputModel>())).Returns(Task.CompletedTask);

            var result = await _personServices.CreatePerson(model);

            Assert.IsTrue(result.success);
            Assert.AreEqual("OK", result.message);
            Assert.IsNull(result.errors);
            Assert.AreEqual(model, result.data);
        }

        [TestMethod]
        public async Task CreatePerson_InvalidPerson_ReturnsErrors()
        {
            var model = new CreatePersonInputModel("", "651.272.240-03", PersonTypes.Physical, "83993239407", "john.doe@example.com", new List<Address>());

            var result = await _personServices.CreatePerson(model);

            Assert.IsFalse(result.success);
            Assert.AreEqual("Invalid person data", result.message);
            Assert.IsNotNull(result.errors);
            Assert.AreEqual(1, result.errors?.Count());
        }

        [TestMethod]
        public async Task DeletePerson_InvalidId_ReturnsErrors()
        {
            var model = new DeletePersonInputModel { Id = Guid.NewGuid() };

            _repositoryMock.Setup(repo => repo.GetPersonByIdAsync(It.IsAny<GetPersonByIdInputModel>()));

            var result = await _personServices.DeletePerson(model);

            Assert.IsFalse(result.success);
            Assert.AreEqual("Invalid Id", result.message);
            Assert.IsNull(result.errors);
            Assert.IsNull(result.data);
        }

        [TestMethod]
        public async Task GetAllPeoples_ReturnsListOfPeople()
        {
            var model = new GetAllPeoplesInputModel();

            _repositoryMock.Setup(repo => repo.GetAllPeoplesAsync(model));

            var result = await _personServices.GetAllPeoples(model);

            Assert.IsTrue(result.success);
            Assert.AreEqual("OK", result.message);
            Assert.IsNull(result.errors);
        }

        [TestMethod]
        public async Task GetPersonById_InvalidId_ReturnsErrors()
        {
            var model = new GetPersonByIdInputModel { Id = Guid.NewGuid() };

            _repositoryMock.Setup(repo => repo.GetPersonByIdAsync(It.IsAny<GetPersonByIdInputModel>()));

            var result = await _personServices.GetPersonById(model);

            Assert.IsFalse(result.success);
            Assert.AreEqual("Invalid Id", result.message);
            Assert.IsNull(result.errors);
            Assert.IsNull(result.data);
        }


    }
}
