using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELL.Models;
using ELL.DBContext;
using ELL.Services;

namespace ELL.Controllers
{
    public class ParentsController : Controller
    {
        private ParentService _parentService;

        public ParentsController()
        {
            _parentService = new ParentService();
        }

        // GET: Parents
        public async Task<ActionResult> Index()
        {
            var parents = await _parentService.GetAll();

            return View(parents);
        }

        // GET: Parents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Parent parent = await _parentService.Get(id.Value);

            if (parent == null)
            {
                return HttpNotFound();
            }

            return View(parent);
        }

        // GET: Parents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Phone")] Parent parent)
        {
            if (ModelState.IsValid)
            { 
                await _parentService.Create(parent);

                return RedirectToAction("Index");
            }

            return View(parent);
        }

        // GET: Parents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Parent parent = await _parentService.Get(id.Value);

            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Phone")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                await _parentService.Update(parent);

                return RedirectToAction("Index");
            }
            return View(parent);
        }

        // GET: Parents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = await _parentService.Get(id.Value);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Parent parent = await _parentService.Get(id);

            await _parentService.Delete(parent.Id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
