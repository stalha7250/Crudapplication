using CrudApplication.Models;
using CrudApplication.net4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CrudApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid) {  
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
                TempData["sucess"] = "Student Register successfully";
                return RedirectToAction("ViewStudent", "Home");
             }
            return View();
        }
        [HttpGet]
        public IActionResult ViewStudent()
        {
            var students = _dbContext.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x=>x.Id==id);
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
                TempData["update"] = "Student update successfully";
                return RedirectToAction("ViewStudent", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _dbContext.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
           
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
                TempData["delete"] = "Student Deleted successfully";
                return RedirectToAction("ViewStudent", "Home");
          
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
