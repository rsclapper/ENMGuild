using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models;
using EntityState = System.Data.Entity.EntityState;

namespace GuildENM.Controllers
{
    public class AttachmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attachments
        public async Task<ActionResult> Index()
        {
            var attachments = db.Attachments.Include(a => a.StudentUser);
            return View(await attachments.ToListAsync());
        }

        // GET: Attachments/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // GET: Attachments/Create
        public ActionResult Create()
        {
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentUserId,Id,Name,Path,AttachmentTypeId")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", attachment.StudentUserId);
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", attachment.StudentUserId);
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentUserId,Id,Name,Path,AttachmentTypeId")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", attachment.StudentUserId);
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachment attachment = await db.Attachments.FindAsync(id);
            if (attachment == null)
            {
                return HttpNotFound();
            }
            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Attachment attachment = await db.Attachments.FindAsync(id);
            db.Attachments.Remove(attachment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
