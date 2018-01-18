using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AssessmentCfbPractice.Controllers
{
    public class ContactsController : Controller
    {
        protected AssessmentModel db = new AssessmentModel();

        public async Task<ActionResult> GetContacts()
        {
            return Json(await db.Contacts.ToListAsync(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        //// GET: Contacts/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Contact contact = await db.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(contact);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(Contact contact)
        {
            var status = "success";
            try
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


            }
            catch (Exception e)
            {
                status = e.Message;
            }


            return Json(status, JsonRequestBehavior.AllowGet);
        }

        // GET: Contacts/Edit/5
        public  async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(Contact contact)
        {
            var status = "success";
            try
            {

                var emailExist = await db.Contacts.Where(x => x.Email == contact.Email).ToListAsync();

                if (emailExist.SingleOrDefault() == null)
                {
                    db.Entry(contact).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                }
                else
                {
                    status = "Contact already Exist";
                }

            }
            catch (Exception e)
            {
                status = e.Message;
            }



            return Json(status, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
