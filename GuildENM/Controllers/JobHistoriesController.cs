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
    public class JobHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobHistories
        public async Task<ActionResult> Index()
        {
            var jobHistories = db.JobHistories.Include(j => j.StudentUser);
            return View(await jobHistories.ToListAsync());
        }

        // GET: JobHistories/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = await db.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // GET: JobHistories/Create
        public ActionResult Create()
        {
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: JobHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentUserId,Id,CompanyName,Title,Description,StartDate,EndDate")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                db.JobHistories.Add(jobHistory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", jobHistory.StudentUserId);
            return View(jobHistory);
        }

        // GET: JobHistories/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = await db.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", jobHistory.StudentUserId);
            return View(jobHistory);
        }

        // POST: JobHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentUserId,Id,CompanyName,Title,Description,StartDate,EndDate")] JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobHistory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StudentUserId = new SelectList(db.Users, "Id", "FirstName", jobHistory.StudentUserId);
            return View(jobHistory);
        }

        // GET: JobHistories/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobHistory jobHistory = await db.JobHistories.FindAsync(id);
            if (jobHistory == null)
            {
                return HttpNotFound();
            }
            return View(jobHistory);
        }

        // POST: JobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            JobHistory jobHistory = await db.JobHistories.FindAsync(id);
            db.JobHistories.Remove(jobHistory);
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
