using Microsoft.AspNetCore.Mvc;
using StudentMukesh.Domain;
using StudentMukesh.Repository.Interfaces;
using StudentMukesh.UI.ViewModels;

namespace StudentMukesh.UI.Controllers
{
    public class PatientsController : Controller
    {
        private IPatient _patientRepo;
        private IMedicine _medicineRepo;

        public PatientsController(IPatient patientRepo, IMedicine medicineRepo)
        {
            _patientRepo = patientRepo;
            _medicineRepo = medicineRepo;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new List<PatientViewModel>();
            var patients= await _patientRepo.GetAll();
            foreach(var item in patients)
            {
                vm.Add(new PatientViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                });
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
           CreatePatientViewModel vm = new CreatePatientViewModel();
            var medicineList = await _medicineRepo.GetAll();
            foreach(var medicine in medicineList)
            {
                vm.MedicineList.Add(new CheckBoxTable
                {
                    Id = medicine.Id,
                    MedicineName = medicine.Name,
                    IsCheck = false
                }); 
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientViewModel vm )
        {
            var patient = new Patient
            {
                Name = vm.PatientName
            };

            var selectedMedicineIds = vm.MedicineList.Where(x=>x.IsCheck==true).Select(b=>b.Id).ToList();// For Retrive selected medicine using checkbox
            
            foreach(var selectedId in selectedMedicineIds)
            {
                patient.PatientMedicines.Add(new PatientMedicine
                {
                    MedicineId = selectedId
                }) ;
            }
           await _patientRepo.Save(patient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient= await _patientRepo.Get(id);
            var PatientMedicineIds = patient.PatientMedicines.Select(x => x.MedicineId).ToList();
            EditPatientViewModel vm = new EditPatientViewModel();
            vm.Id=patient.Id;
            vm.PatientName = patient.Name;
            var medicineLlist = await _medicineRepo.GetAll();
            foreach(var medicine in medicineLlist)
            {
                vm.MedicineList.Add(new CheckBoxTable
                {
                    Id = medicine.Id,
                    MedicineName = medicine.Name,
                    IsCheck = PatientMedicineIds.Contains(medicine.Id)
                });
            }
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPatientViewModel vm)
        {
            var patient = await _patientRepo.Get(vm.Id);
            var existingIds = patient.PatientMedicines.Select(x => x.MedicineId).ToList();
            var selectedIds = vm.MedicineList.Where(x => x.IsCheck == true).Select(b => b.Id).ToList();

            var ToAdd = selectedIds.Except(existingIds).ToList();
            var ToRemove= existingIds.Except(selectedIds).ToList();

            //For Remove Existing Ids
            foreach(var medicineId in ToRemove)
            {
                var patientMedicine = patient.PatientMedicines.FirstOrDefault(x => x.MedicineId == medicineId);
                patient.PatientMedicines.Remove(patientMedicine);
            }

            //For Update New/Selecetd checkboxxIds
            foreach(var selctedId in ToAdd)
            {
                patient.PatientMedicines.Add(new PatientMedicine
                {
                    MedicineId = selctedId
                });
            }

           await _patientRepo.Update(patient);
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public async Task< IActionResult> Delete(int id)
        {
           await _patientRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
