using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBA_CRUD_ASP.NET_MVC.Models;

namespace DBA_CRUD_ASP.NET_MVC.Controllers
{
    public class MemoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Memo
        public async Task<ActionResult> Index()
        {
            return View(await db.Memo.ToListAsync());
        }

        // GET: Memo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = await db.Memo.FindAsync(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // GET: Memo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Memo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Body")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Memo.Add(memo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(memo);
        }

        // GET: Memo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = await db.Memo.FindAsync(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: Memo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Body")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(memo);
        }

        // GET: Memo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = await db.Memo.FindAsync(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: Memo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Memo memo = await db.Memo.FindAsync(id);
            db.Memo.Remove(memo);
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
