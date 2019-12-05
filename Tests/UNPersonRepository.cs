using Core.Interfaces.Repositories;
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class UNPersonRepository:BaseTestRepsotiory
    {

        private IPersonRepository _personRepository;
        public UNPersonRepository()
        {
            _personRepository = new PersonRepository(DbContext);
        }
    
        [TestMethod]
        public async Task<Person> AddTest()
        {
            var person = new Person { FirstName = "Mehdi", LastName = "Rifi", BirthDate = new DateTime(1995, 05, 18) };
            await _personRepository.Add(person);
            Assert.IsTrue(person.Id > 0);
            return person;
        }
        [TestMethod]
        public async Task GetByIdTest()
        {
            await AddTest();
            var person = await _personRepository.GetById(1);
            Assert.IsTrue(person != null);
        }
        [TestMethod]
        public async Task DeleteById()
        {

            var person = await AddTest();
            await _personRepository.Delete(person);
            person = await _personRepository.GetById(1);
            Assert.IsTrue(person == null);
        }




    }
}
