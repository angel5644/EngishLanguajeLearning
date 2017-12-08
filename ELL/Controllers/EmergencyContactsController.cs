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
    public class EmergencyContactsController : Controller
    {
        private ParentService _parentService;

        public EmergencyContactsController()
        {
            _parentService = new ParentService();
        }

        // GET: EmergencyContacts
        public async Task<ActionResult> Index()
        {
            var emergencyContacts = await _parentService.GetAll();

            return View(emergencyContacts);
        }

        // GET: EmergencyContacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmergencyContact contact = await _parentService.Get(id.Value);

            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // GET: EmergencyContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Phone")] EmergencyContact contact)
        {
            if (ModelState.IsValid)
            { 
                await _parentService.Create(contact);

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmergencyContact contact = await _parentService.Get(id.Value);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: EmergencyContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Phone")] EmergencyContact contact)
        {
            if (ModelState.IsValid)
            {
                await _parentService.Update(contact);

                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: EmergencyContacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmergencyContact contact = await _parentService.Get(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: EmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmergencyContact contact = await _parentService.Get(id);

            await _parentService.Delete(contact.Id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
