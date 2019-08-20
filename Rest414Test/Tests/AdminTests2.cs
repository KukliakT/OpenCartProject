﻿using NUnit.Framework;
using Rest414Test.Data;
using Rest414Test.Services;
using System;

namespace Rest414Test.Tests
{
    [TestFixture]
    public class AdminTests2
    {
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
        }

        [Test]
        public void CheckLoggingInAdmin()
        {
            adminService.SuccessfulAdminLogin(adminForTest);
            string allLoggedInAdmins = adminService.GetLoggedInAdmins();
            Assert.IsTrue(allLoggedInAdmins.Contains(adminForTest.Name));
        }
    }
}