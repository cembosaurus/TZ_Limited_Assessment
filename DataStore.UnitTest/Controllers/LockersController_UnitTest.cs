﻿using DataStore.Controllers;
using DataStore.Data;
using DataStore.DTOs;
using DataStore.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DataStore.UnitTest.Data
{

    [TestFixture]
    class LockersController_UnitTest
    {

        private Mock<LockersDTO> _lockers;

        [SetUp]
        public void SetUp()
        {
            _lockers = new Mock<LockersDTO>();
        }

        [Test]
        public void Get_test()
        {
            var repo = new Mock<ILockersRepository>();
            repo.Setup(s => s.Lockers()).ReturnsAsync(_lockers.Object);
            var controller = new LockersController(repo.Object);

            var result = controller.Get();
            var data = result.Result;
           
            Assert.IsInstanceOf<Task<IActionResult>>(result);
            Assert.That(data, Is.InstanceOf<OkObjectResult>());
        }

    }

}
