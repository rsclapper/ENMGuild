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
    public class StudentUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentUsers
        public async Task<ActionResult> Index()
        {
            var applicationUsers = db.StudentUsers;
            return View(await applicationUsers.ToListAsync());
        }

        // GET: StudentUsers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = await db.StudentUsers.FindAsync(id);
            if (studentUser == null)
            {
                return HttpNotFound();
            }
            return View(studentUser);
        }

        // GET: StudentUsers/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Attachments, "StudentUserId", "Name");
            ViewBag.Id = new SelectList(db.JobHistories, "StudentUserId", "CompanyName");
            return View();
        }

        // POST: StudentUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,GraudationDate,ProfileUrl")] StudentUser studentUser)
        {
            if (ModelState.IsValid)
            {
                db.StudentUsers.Add(studentUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Attachments, "StudentUserId", "Name", studentUser.Id);
            ViewBag.Id = new SelectList(db.JobHistories, "StudentUserId", "CompanyName", studentUser.Id);
            return View(studentUser);
        }

        // GET: StudentUsers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = await db.StudentUsers.FindAsync(id);
            if (studentUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Attachments, "StudentUserId", "Name", studentUser.Id);
            ViewBag.Id = new SelectList(db.JobHistories, "StudentUserId", "CompanyName", studentUser.Id);
            return View(studentUser);
        }

        // POST: StudentUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,GraudationDate,ProfileUrl")] StudentUser studentUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Attachments, "StudentUserId", "Name", studentUser.Id);
            ViewBag.Id = new SelectList(db.JobHistories, "StudentUserId", "CompanyName", studentUser.Id);
            return View(studentUser);
        }

        // GET: StudentUsers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentUser studentUser = await db.StudentUsers.FindAsync(id);
            if (studentUser == null)
            {
                return HttpNotFound();
            }
            return View(studentUser);
        }

        // POST: StudentUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            StudentUser studentUser = await db.StudentUsers.FindAsync(id);
            db.StudentUsers.Remove(studentUser);
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
