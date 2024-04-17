using Microsoft.AspNetCore.Mvc;
using StudentMukesh.Web.Data;
using StudentMukesh.Web.Models;
using StudentMukesh.Web.ViewModels;

namespace StudentMukesh.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // IEnumerable<>, List<>, Collection<>, IQuerable<>

        public IActionResult Index()
        {
            var modelList = _context.Peoples.ToList();

            List<PeopleViewModel> list = new List<PeopleViewModel>();
            foreach (var item in modelList)
            {
                list.Add(new PeopleViewModel { PeopleId = item.Id, PeopleName = item.Name });
            }
            
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatePeopleViewModel vm)
        {
            var people = new People
            {
                Name = vm.PeopleName
            };
            _context.Peoples.Add(people);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var people = _context.Peoples.Find(id);
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleId = people.Id;
            vm.PeopleName = people.Name;

            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(PeopleViewModel vm)
        {
            var model = new People
            {
                Id = vm.PeopleId,
                Name = vm.PeopleName
            };
            _context.Peoples.Update(model);
            _context.SaveChanges(); 

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var people = _context.Peoples.Find(id);
            _context.Peoples.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
