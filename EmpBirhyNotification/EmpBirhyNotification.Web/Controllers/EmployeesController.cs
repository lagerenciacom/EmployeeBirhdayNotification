using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpBirhyNotification.Web.Models;
using EmpBirhyNotification.Web.Helpers;

namespace EmpBirhyNotification.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Gender).Include(e => e.Status);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Description");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Description");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description");

            var view = new EmployeeView();

            return View(view);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( EmployeeView view)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee {
                    Address = view.Address,
                    HireDate = view.HireDate,
                    DepartmentId = view.DepartmentId,
                    Email = view.Email,
                    EmployeeId = view.EmployeeId,
                    Name = view.Name,
                    GenderId = view.GenderId,
                    LastName = view.LastName,
                    Password = view.Password,
                    StatusId = view.StatusId,
                    Salary = view.Salary,                    
                    Tel = view.Tel
                };

                var pic = string.Empty;

                if (view.PictureFile != null)
                {
                    var folder = "~/Content/EmployeePics";

                    pic = FilesHelper.UploadPhoto(view.PictureFile, folder, "");
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                employee.PictureRoute = pic;

                db.Employees.Add(employee);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Description", view.DepartmentId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Description", view.GenderId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", view.StatusId);
            return View(view);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Description", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Description", employee.GenderId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", employee.StatusId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Description", employee.DepartmentId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "Description", employee.GenderId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "Description", employee.StatusId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
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
