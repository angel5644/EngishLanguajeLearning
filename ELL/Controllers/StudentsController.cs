using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ELL.DBContext;
using ELL.Models;
using ELL.Services;
using ELL.ViewModels.Students;
using AutoMapper;
using ELL.ViewModels.Payments;

namespace ELL.Controllers
{
    public class StudentsController : ELLBaseController
    {
        private ELLDBContext db = new ELLDBContext();
        private StudentService _studentService;
        private EmergencyContactService _emergencyContactService;

        public StudentsController()
        {
            _studentService = new StudentService();
            _emergencyContactService = new EmergencyContactService();
        }

        // GET: Students
        public async Task<ActionResult> Index()
        {
            var students = await _studentService.GetALlIncludeContact();

            List<StudentVM> studentsVM = new List<StudentVM>();
            foreach (var student in students)
            {
                // Map from Student to StudentVM
                StudentVM studentVM = AutoMapper.Mapper.Map<Student, StudentVM>(student);

                studentsVM.Add(studentVM);
            }

            return View(studentsVM);
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = await _studentService.Get(id.Value);

            // Map from Student to StudentVM
            StudentVM studentVM = AutoMapper.Mapper.Map<Student, StudentVM>(student);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(studentVM);
        }

        // GET: Students/Create
        public async Task<ActionResult> Create()
        {
            CreateStudentVM model = new CreateStudentVM();

            model.EmergencyContacts = await DropEmergerncyContacts();
            model.BirthDate = DateTime.UtcNow;

            return View(model);
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = Mapper.Map<CreateStudentVM, Student>(studentVM);

                await _studentService.Create(newStudent);

                Success("Student was added successfully");

                return RedirectToAction("Index");
            }

            studentVM.EmergencyContacts = await DropEmergerncyContacts();

            return View(studentVM);
        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _studentService.Get(id.Value);

            // Map from entity to view model
            CreateStudentVM studentVM = Mapper.Map<Student, CreateStudentVM>(student);

            if (student == null)
            {
                return HttpNotFound();
            }
            studentVM.EmergencyContacts = await DropEmergerncyContacts();

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateStudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<CreateStudentVM, Student>(studentVM);

                await _studentService.Update(student);

                Success("Student was updated successfully");

                return RedirectToAction("Index");
            }

            studentVM.EmergencyContacts = await DropEmergerncyContacts();

            return View(studentVM);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await _studentService.Get(id.Value);

            // Map from Student to StudentVM
            StudentVM studentVM = AutoMapper.Mapper.Map<Student, StudentVM>(student);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(studentVM);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await _studentService.Get(id);

            await _studentService.Delete(student.Id);

            Success("Student was deleted successfully");

            return RedirectToAction("Index");
        }

        private async Task<SelectList> DropEmergerncyContacts()
        {
            var contacts = (await _emergencyContactService.GetAll()).Select(s => new
            {
                Id = s.Id,
                FullName = s.FullName
            });

            return new SelectList(contacts, "Id", "FullName");
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
