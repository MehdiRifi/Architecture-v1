﻿using Core.Interfaces.Repositories;
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]

    public class UNGenericRepository:BaseTestRepsotiory
    {
        private IRepository<Person> _repository;
        public UNGenericRepository()
        {
            _repository = new EFRepository<Person>(DbContext);
        }
        [TestMethod]
        public async Task<Person> AddTest()
        {
            var person = new Person { FirstName = "Mehdi", LastName = "Rifi", BirthDate = new DateTime(1995, 05, 18) };
            await _repository.Add(person);
            Assert.IsTrue(person.Id > 0);
            return person;
        }
        [TestMethod]
        public async Task GetByIdTest()
        {
            await AddTest();
            var person = await _repository.GetById(1);
            Assert.IsTrue(person != null);
        }
        [TestMethod]
        public async Task DeleteById()
        {

            var person =await AddTest();
            await _repository.Delete(person);
            person = await _repository.GetById(1);
            Assert.IsTrue(person == null);
        }
    }
}
