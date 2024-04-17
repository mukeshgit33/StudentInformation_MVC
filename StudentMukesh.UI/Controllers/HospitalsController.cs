using Microsoft.AspNetCore.Mvc;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Interfaces;
using StudentMukesh.UI.ViewModels;

namespace StudentMukesh.UI.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly IHospital _hospitalRepo;
        private IUtilityService _utilityService;
        private string ContainerName = "HospitalImage";
        public HospitalsController(IHospital hospitalRepo, IUtilityService utilityService)
        {
            _hospitalRepo = hospitalRepo;
            _utilityService = utilityService;
        }

        public async Task<IActionResult> Index()
        {
            //List<HospitalViewModel> vm = new List<HospitalViewModel>();
            //OR
            var vm = new List<HospitalViewModel>();
            var result = await _hospitalRepo.GetAll();
            foreach (var item in result)
            {
                vm.Add(new HospitalViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    HospitalImage =  item.HospitalImage,
                   
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
        public async Task <IActionResult> Create(HospitalViewModel vm)
        {
            var model = new Hospital();
            model.Name = vm.Name;
            if(vm.ChooseHospitalImage != null)
            {
                model.HospitalImage = await _utilityService.SaveImage(ContainerName, vm.ChooseHospitalImage);
            }
            await _hospitalRepo.Save(model);
            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Update(int Id)
        {
            var result = await _hospitalRepo.Get(Id);
            var vm = new HospitalViewModel();
            vm.Id = result.Id;
            vm.Name = result.Name;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(HospitalViewModel vm)
        {
            var model = new Hospital();
            model.Id = vm.Id;
            model.Name = vm.Name;
          await _hospitalRepo.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
           await _hospitalRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}