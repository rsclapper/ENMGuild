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
    public class NotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notes
        public async Task<ActionResult> Index()
        {
            var notes = db.Notes.Include(n => n.Student);
            return View(await notes.ToListAsync());
        }

        // GET: Notes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            ViewBag.EmploymentManagerId = new SelectList(db.StudentUsers, "Id", "FirstName");
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmploymentManagerId,Id,Content,CreatedDate,UpdatedDate")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmploymentManagerId = new SelectList(db.StudentUsers, "Id", "FirstName", note.EmploymentManagerId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmploymentManagerId = new SelectList(db.StudentUsers, "Id", "FirstName", note.EmploymentManagerId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmploymentManagerId,Id,Content,CreatedDate,UpdatedDate")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmploymentManagerId = new SelectList(db.StudentUsers, "Id", "FirstName", note.EmploymentManagerId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = await db.Notes.FindAsync(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Note note = await db.Notes.FindAsync(id);
            db.Notes.Remove(note);
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
