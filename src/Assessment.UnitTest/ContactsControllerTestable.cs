using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AssessmentCfbPractice;
using AssessmentCfbPractice.Controllers;

namespace Assessment.UnitTest
{
    public class ContactsControllerTestable : ContactsController
    {
        public override async Task<ActionResult> Create(Contact contact)
        {
            var status = "success";
            try
            {
                using (var txn = db.Database.BeginTransaction())
                {
                    var emailExist = await db.Contacts.Where(x => x.Email == contact.Email).ToListAsync();

                    if (emailExist.SingleOrDefault() == null)
                    {
                        db.Contacts.Add(contact);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        status = "Contact already Exist";
                    }

                    txn.Rollback();
                }
            }
            catch (Exception e)
            {
                status = e.Message;
            }


            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public override async Task<ActionResult> Edit(Contact contact)
        {
            string status;
            try
            {

                using (var txn = db.Database.BeginTransaction())
                {
                    var emailExist = await db.Contacts.Where(x => x.Email == contact.Email).ToListAsync();

                    if (emailExist.SingleOrDefault() == null)
                    {
                        db.Entry(contact).State = EntityState.Modified;
                        var changes = await db.SaveChangesAsync();

                        status = changes <= 0 ? "Fail updating contact" : "success";
                    }
                    else
                    {
                        status = "Contact already Exist";
                    }

                    txn.Rollback();
                }

            }
            catch (Exception e)
            {
                status = e.Message;
            }



            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}
