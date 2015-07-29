using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using IDGenerator;
using IDGenerator.Controllers;


namespace IDGenerator.Tests.Controllers
{
    [TestClass]
    public class IDManagementControllerTest
    {
        [TestMethod]
        public void SuccessfullPostShouldReturnAValidID()
        {
            Models.User u = new  Models.User
            {
                country = "SA",
                dateOfBirth = "950312",
                gender = "male"

            };
            // Arrange
            IDManagementController controller = new IDManagementController();

            // Act
            Models.ResponseObject res = controller.Post(u);

            // Assert
            Assert.AreEqual("success", res.message);
            Assert.IsFalse(res.id == null);
            Assert.IsTrue(res.id.ToString().Length == 13);

        }
        [TestMethod]
        public void InvalidPostShouldReturnAnErrorMessage()
        {
            Models.User u = new Models.User
            {
                country = "SA",
                dateOfBirth = "950312"

            };
            // Arrange
            IDManagementController controller = new IDManagementController();

            // Act
            Models.ResponseObject res = controller.Post(u);

            // Assert
            Assert.AreEqual("Some of the required fields were empty", res.message);
            Assert.IsTrue(res.id == null);
           

        }

    }
}
