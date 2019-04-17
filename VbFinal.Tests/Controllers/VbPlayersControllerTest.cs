using System;
using System.Collections.Generic;
using System.Linq;
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
                    VbPlayerId = 961,
                    FirstName = "Zak",
                    Lastname = "N",
                    Photo = "https://img.icons8.com/ultraviolet/384/beach-volleyball.png"
                }
            };

            mock.Setup(m => m.VbPlayers).Returns(vbPlayers.AsQueryable());
            controller = new VbPlayersController(mock.Object);
        }
    }
}
