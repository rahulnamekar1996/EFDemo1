using EFDemo1.Data;
using EFDemo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFDemo1.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db;
        StudentDAL dal;

        public StudentController(ApplicationDbContext db)
        {
            this.db = db;
            dal = new StudentDAL(this.db);
        }
       
        public ActionResult Index()
        {
            var model = dal.GetStudent();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var student = dal.GetStudentById(id);
            return View(student);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {

            try
            {
                int result = dal.AddStudent(std);
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
            var std = dal.GetStudentById(id);
            return View(std);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {
                int result = dal.EditStudent(std);
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
            var std = dal.GetStudentById(id);
            return View(std);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = dal.DeleteStudent(id);
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
