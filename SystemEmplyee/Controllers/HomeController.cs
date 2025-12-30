using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SystemEmplyee.Models;
using SystemEmplyee.Repositer;

namespace SystemEmplyee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee repo;
        private readonly IWebHostEnvironment _ev;

        public HomeController(IEmployee employee,IWebHostEnvironment ev)
        {
            repo= employee;
            _ev= ev;
        }

        public IActionResult Index()
        {
            var row = repo.EmployeeList();
            return View(row);
        }

        public IActionResult Details(int id)
        {
            var row=repo.GetEmployeeDetailsById(id);
            return View(row);
        }

        public IActionResult Delete(int id)
        {
            repo.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var candidate = repo.GetEmployeeDetailsById(id);
            if (candidate == null)
                return NotFound();

            var countries = repo.CountryList() ?? new List<CountryDbModel>();
            ViewBag.country = new SelectList(countries,"CountryId","CountryName",candidate.CountId);

            var cities = repo.CityList(candidate.StatId) ?? new List<CityDbModel>();
            ViewBag.city = new SelectList(cities,"CityId","CityName",candidate.CityId);

            var departments = repo.DepartmentList() ?? new List<DepartmentDbModel>();
            ViewBag.department = new SelectList(departments, "DepartmentId", "DepartmentName", candidate.Dept);

            return View(candidate);
        }


        [HttpPost]
        public IActionResult Update(int id,EmployeeDbModel dbModel)
        {
            if(ModelState.IsValid)
            {
                string fileName = null;

                if(dbModel.photoFile!=null && dbModel.photoFile.Length>0)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(dbModel.photoFile.FileName);

                    string uploadPath = Path.Combine(_ev.WebRootPath, "Images");
                    if(!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string filePath=Path.Combine(uploadPath, fileName);

                    using(var stream=new FileStream(filePath,FileMode.Create))
                    {
                        dbModel.photoFile.CopyTo(stream);
                    }

                    dbModel.Photo = fileName;
                }
            }

            repo.UpdateEmployee(id, dbModel);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var row = repo.DepartmentList();
            ViewBag.Designation = new SelectList(row, "DepartmentId", "DepartmentName");
            var list=repo.CountryList();
            ViewBag.Country = new SelectList(list, "CountryId","CountryName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDbModel model)
        {
            if (ModelState.IsValid) 
            {

                string fileName = null;

                if(model.photoFile != null && model.photoFile.Length>0)
                {
                    fileName=Guid.NewGuid().ToString()+Path.GetExtension(model.photoFile.FileName);

                    string uploadPath=Path.Combine(_ev.WebRootPath, "Images");
                    if(!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string filePath = Path.Combine(uploadPath, fileName);

                    using(var stream=new FileStream(filePath,FileMode.Create))
                    {
                        model.photoFile.CopyTo(stream);
                    }

                    model.Photo = fileName;
                }

                repo.CreateEmployee(model);
                return RedirectToAction("Index");
            }

            var row = repo.DepartmentList();
            ViewBag.Designation = new SelectList(row, "DepartmentId", "DepartmentName");
            var list = repo.CountryList();
            ViewBag.Country = new SelectList(list, "CountryId", "CountryName");
            return View(model);

        }

        [HttpPost]
        public JsonResult GetStateName(int countryId)
        {
            var state = repo.StateList(countryId);
            return Json(state);
        }

        [HttpPost]
        public JsonResult GetCityName(int stateId)
        {
            var city=repo.CityList(stateId);
            return Json(city);
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
