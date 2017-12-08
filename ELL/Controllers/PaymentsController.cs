using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ELL.DBContext;
using ELL.Models;
using ELL.Services;
using ELL.ViewModels.Payments;
using AutoMapper;
using FXWell.Core;

namespace ELL.Controllers
{
    public class PaymentsController : ELLBaseController
    {
        private ELLDBContext db = new ELLDBContext();
        private PaymentService _paymentService;
        private StudentService _studentService;

        public PaymentsController()
        {
            _paymentService = new PaymentService();
            _studentService = new StudentService();
        }

        // GET: Payments
        public async Task<ActionResult> Index()
        {
            var payments = await _paymentService.GetALlIncludeStudent();

            return View(payments);
        }

        // GET: Payments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Payment payment = await _paymentService.Get(id.Value);

            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public async Task<ActionResult> Create()
        {
            CreatePaymentVM model = new CreatePaymentVM();

            var students = (await _studentService.GetAll()).Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName
            });
            model.Students = new SelectList(students, "Id", "FullName");

            return View(model);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StudentId,Amount,Description")] CreatePaymentVM paymentVM)
        {
            if (ModelState.IsValid)
            {
                Payment newPayment = Mapper.Map<CreatePaymentVM, Payment>(paymentVM);

                await _paymentService.Create(newPayment);

                Success("Payment was added successfully");
                
                return RedirectToAction("Index");
            }

            var students = (await _studentService.GetAll()).Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName
            });
            paymentVM.Students = new SelectList(students, "Id", "FullName");

            return View(paymentVM);
        }

        // GET: Payments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get payment by id
            Payment payment = await _paymentService.Get(id.Value);

            if (payment == null)
            {
                return HttpNotFound();
            }

            // Map payment to view model
            CreatePaymentVM paymentVM = Mapper.Map<Payment, CreatePaymentVM>(payment);

            var students = (await _studentService.GetAll()).Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName
            });
            paymentVM.Students = new SelectList(students, "Id", "FullName", payment.StudentId);

            return View(paymentVM);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StudentId,Amount,Description")] CreatePaymentVM paymentVM)
        {
            if (ModelState.IsValid)
            {
                // Map from view model to entity
                Payment paymentUpdate = Mapper.Map<CreatePaymentVM, Payment>(paymentVM);

                // Update payment
                await _paymentService.Update(paymentUpdate);

                // Set success message
                Success("Payment was updated successfully");

                return RedirectToAction("Index");
            }
            var students = (await _studentService.GetAll()).Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName
            });
            paymentVM.Students = new SelectList(students, "Id", "FullName", paymentVM.StudentId);

            return View(paymentVM);
        }

        // GET: Payments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Payment payment = await _paymentService.Get(id.Value);

            if (payment == null)
            {
                return HttpNotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Payment payment = await _paymentService.Get(id);
            await _paymentService.Delete(payment.Id);

            // Message
            Success("Payment was deleted successfully");

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
