using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Interface;
using StudentMukesh.Repository.Interfaces;
using StudentMukesh.UI.ViewModels;

namespace StudentMukesh.UI.Controllers
{
    // Data Transfer Object:  ViewBag.DynamicVariable =new Hospital{id=1, Name="Public Hospital"}, ViewData, TempData : peek, keep
    public class DoctorsController : Controller
    {
        private readonly IDoctor _doctorRepo;
        private readonly IHospital _hospitalRepo;

        public DoctorsController(IDoctor doctorRepo, IHospital hospitalRepo)
        {
            _doctorRepo = doctorRepo;
            _hospitalRepo = hospitalRepo;
        }

        public async Task< IActionResult> Index()
        {
            var vm = new List<DoctorViewModel>();
            var doctorList = await _doctorRepo.GetAll();
            foreach (var item in doctorList)
            {
                vm.Add(new DoctorViewModel
                {
                    DoctorId=item.Id,
                    DoctorName=item.Name
                   
                  
                });
            }
            return View(vm);
        }
        [HttpGet]
        //{baseurl}/doctors/create
        public async Task<IActionResult> Create()
        {
            var hospitals = await _hospitalRepo.GetAll();
            ViewBag.hospitalList = new SelectList(hospitals, "Id", "Name");
          
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreateDoctorViewModel vm)
        {
            var model = new Doctor();
            model.Name = vm.DoctorName;
            model.HospitalId = vm.HospitalId;
            
            await _doctorRepo.Save(model);
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {

            var doctor = await _doctorRepo.GetById(id);
            var vm = new DoctorViewModel
            {
                DoctorId = doctor.Id,
                DoctorName = doctor.Name,
                HospitalId = doctor.HospitalId

            };
            var hospitals = await _hospitalRepo.GetAll();
            ViewBag.hospitalList = new SelectList(hospitals, "Id", "Name");

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorViewModel vm)
        {
            var model = new Doctor();
            model.Id= vm.DoctorId;
            model.Name = vm.DoctorName;
            model.HospitalId= vm.HospitalId;
           await _doctorRepo.Update(model);
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
           await _doctorRepo.DeleteById(Id);
            return RedirectToAction("Index");
        }

    }
}
