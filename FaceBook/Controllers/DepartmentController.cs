using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;

namespace FaceBook.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepo dept;
        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            dept= departmentRepo;
        }
        public IActionResult getAll()
        {
            
            return View(dept.getAll());
        }
    }
}
