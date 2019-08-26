﻿using NLog;
using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests2
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        AdminService adminService;
        IUser adminForTest;

        [SetUp]
        public void SetUp()
        {
            IUser adminUser = UserRepository.Get().Admin();
            GuestService guestService = new GuestService();
            adminService = guestService
                .SuccessfulAdminLogin(adminUser);
            adminForTest = UserRepository.Get().AdminForTest();
            adminService.AddAdmin(adminForTest);
        }

        [TearDown]
        public void TearDown()
        {
            adminService.Logout(adminForTest);
            adminService.RemoveUser(adminForTest);
            adminService.Logout();
        }

        [Test]
        public void CheckLoggingInAdmin()
        {
            logger.Info("Checking logging admin in started.");
            adminService.SuccessfulAdminLogin(adminForTest);
            Assert.IsTrue(adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Is logged in admin: " + adminService.IsLoggedInAdmin(adminForTest));
            logger.Info("Checking logging admin in done.");
        }

        [Test]
        public void CheckAddingSameNameUser()
        {
            logger.Info("Checking adding a user with the same name as previously removed admin's started.");
            adminService.RemoveUser(adminForTest);
            adminService.CreateUser(adminForTest);
            Assert.Throws<Exception>(()=>adminService.SuccessfulAdminLogin(adminForTest));
            logger.Info("Expected exception is thrown.");
            logger.Info("Checking adding a user with the same name as previously removed admin's done.");
        }
    }
}
