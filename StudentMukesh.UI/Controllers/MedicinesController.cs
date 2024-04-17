using Microsoft.AspNetCore.Mvc;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Implementations;
using StudentMukesh.Repository.Interfaces;
using StudentMukesh.UI.ViewModels;

namespace StudentMukesh.UI.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IMedicine _medicine;

        public MedicinesController(IMedicine medicine)
        {
            _medicine = medicine;
        }

        public async Task<IActionResult> Index()
        {
            //List<MedicineViewModel> vm = new List<MedicineViewModel>();
            //OR
            var vm = new List<MedicineViewModel>();
            var result = await _medicine.GetAll();
            foreach (var item in result)
            {
                vm.Add(new MedicineViewModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreateMedicineViewModel vm)
        {
            var model = new Medicine();
            model.Name = vm.MedicineName;
           await _medicine.Save(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var result = await _medicine.Get(id);
            var vm = new MedicineViewModel();
            vm.Id = result.Id;
            vm.Name = result.Name;

            return View(vm);
        }
        [HttpPost]
        public async Task< IActionResult> Update(MedicineViewModel vm)
        {
            var model = new Medicine();
            model.Id = vm.Id;
            model.Name = vm.Name;
           await _medicine.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
           await _medicine.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
