using EFDemo1.Data;
using EFDemo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDemo1.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db;
        EmployeeDAL dal;

        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
            dal = new EmployeeDAL(this.db);
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = dal.GetEmployees();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employee = dal.GetEmployeeById(id);
            return View(employee);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee std)
        {

            try
            {
                int result = dal.AddEmployee(std);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var std = dal.GetEmployeeById(id);
            return View(std);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = dal.EditEmployee(emp);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var std = dal.GetEmployeeById(id);
            return View(std);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = dal.DeleteEmployee(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
