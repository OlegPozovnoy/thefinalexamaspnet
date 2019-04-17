using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VbFinal.Controllers;
using VbFinal.Models;

namespace VbFinal.Tests.Controllers
{
    [TestClass]
    public class VbPlayersControllerTest
    {
        VbPlayersController controller;
        Mock<IMockVbPlayer> mock;
        List<VbPlayer> vbPlayers;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockVbPlayer>();

            vbPlayers = new List<VbPlayer>
            {
                new VbPlayer
                {
                    VbPlayerId = 961,
                    FirstName = "Lori",
                    Lastname = "S",
                    Photo = "https://img.icons8.com/color/384/beach-volleyball.png"
                },
                new VbPlayer
                {
                    VbPlayerId = 962,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            controller = new VbPlayersController(mock.Object);
        }

        //    a.IndexViewLoads – Loads the Index view
        [TestMethod]
        public void IndexViewLoads()
        {
            ViewResult result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }



        //b.IndexValidLoadsVbPlayers – Returns a list of all VbPlayers

        [TestMethod]
        public void IndexValidLoadsVbPlayers()
        {

            var results = (List<VbPlayer>)((ViewResult)controller.Index()).Model;
            CollectionAssert.AreEqual(vbPlayers.ToList(), results);
        }

        //c.EditLoadsValidId – Loads the Edit view

        [TestMethod]
        public void EditLoadsValidId()
        {
            ViewResult result = (ViewResult)controller.Edit(vbPlayers[0].VbPlayerId);
            Assert.AreEqual("Edit", result.ViewName);
        }

        //d.EditLoadsVbPlayerValidId – Loads the correct VbPlayer
        [TestMethod]
        public void EditLoadsVbPlayerValidId()
        {
            VbPlayer result = (VbPlayer)((ViewResult)controller.Edit(vbPlayers[0].VbPlayerId)).Model;
            Assert.AreEqual(vbPlayers[0], result);
        }

        //e.EditInvalidId – Loads the Error View
        [TestMethod]
        public void EditInvalidId()
        {
            ViewResult result = (ViewResult)controller.Edit(-1);
            Assert.AreEqual("Error", result.ViewName);
        }

        //f.EditNoId – Loads the Error View
        [TestMethod]
        public void EditNoId()
        {
            int? id = null;

            var result = (ViewResult)controller.Edit(id);
            Assert.AreEqual("Error", result.ViewName);
        }

        //g.EditSaveInvalid – Loads the Edit view

        [TestMethod]
        public void EditSaveInvalid()
        {
            VbPlayer invalid = new VbPlayer { VbPlayerId = vbPlayers[0].VbPlayerId, FirstName="Oleg", Lastname= "Oleg"  };
            controller.ModelState.AddModelError("Edit Error", "the test is invalid");
            ViewResult result = (ViewResult)controller.Edit(invalid);
            Assert.AreEqual("Edit", result.ViewName);
        }

        //h.EditSaveValid – Redirects to Index

        [TestMethod]
        public void CreateValidTest()
        {
            VbPlayer valid = new VbPlayer { VbPlayerId = vbPlayers[0].VbPlayerId, FirstName = "Oleg", Lastname = "Oleg" };
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(valid);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

    }
}