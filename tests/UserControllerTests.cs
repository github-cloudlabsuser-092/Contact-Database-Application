using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private List<User> _userList;

        [SetUp]
        public void SetUp()
        {
            _userList = new List<User>
            {
                new User { Id = 1, Name = "Test User 1", Email = "test1@example.com" },
                new User { Id = 2, Name = "Test User 2", Email = "test2@example.com" },
                new User { Id = 3, Name = "Test User 3", Email = "test3@example.com" },
            };

            UserController.userlist = _userList;
            _controller = new UserController();
        }

        [Test]
        public void Index_ReturnsCorrectViewWithUsers()
        {
            var result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as List<User>;
            Assert.AreEqual(_userList.Count, model.Count);
        }

        [Test]
        public void Details_ReturnsCorrectUser()
        {
            var result = _controller.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as User;
            Assert.AreEqual(_userList[0].Id, model.Id);
        }

        [Test]
        public void Edit_UpdatesUserCorrectly()
        {
            var updatedUser = new User { Name = "Updated User", Email = "updated@example.com" };
            var result = _controller.Edit(1, updatedUser) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(updatedUser.Name, _userList[0].Name);
            Assert.AreEqual(updatedUser.Email, _userList[0].Email);
        }

        [Test]
        public void Delete_RemovesUserCorrectly()
        {
            var result = _controller.Delete(1, new FormCollection()) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsNull(_userList.Find(u => u.Id == 1));
        }
    }
}
