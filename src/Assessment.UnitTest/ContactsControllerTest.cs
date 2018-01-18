using System.Collections.Generic;
using System.Web.Mvc;
using AssessmentCfbPractice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.UnitTest
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void TestGetContacts()
        {
            var controller = new ContactsControllerTestable();
            var actionResultTask = controller.GetContacts();

            actionResultTask.Wait();

            var result = actionResultTask.Result as JsonResult;

            Assert.IsTrue((result.Data as List<Contact>).Count > 0);
        }

        [TestMethod]
        public void TestCreateContact()
        {
            var contact = new Contact { Email = "correo@correo.com" };
            var controller = new ContactsControllerTestable();
            var actionResultTask = controller.Create(contact);

            actionResultTask.Wait();

            var result = actionResultTask.Result as JsonResult;

            Assert.AreEqual(result.Data.ToString(), "success");
            Assert.AreSame(result.Data.ToString(), "success");
        }

        [TestMethod]
        public void TestEditContact()
        {
            var contact = new Contact { Email = "correo@correo.com", Id = 1};
            var controller = new ContactsControllerTestable();
            var actionResultTask = controller.Edit(contact);

            actionResultTask.Wait();

            var result = actionResultTask.Result as JsonResult;
            
            Assert.AreEqual(result.Data.ToString(),"success");
            Assert.AreSame(result.Data.ToString(), "success");
        }
    }
}
