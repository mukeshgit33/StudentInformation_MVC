using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.UI.ViewModels
{
    public class CreatePatientViewModel
    {
        public  string PatientName { get; set; }
        public List<CheckBoxTable> MedicineList { get; set; }= new List<CheckBoxTable>();
    }

    public class EditPatientViewModel
    {
        public int Id {get; set;}
        public string PatientName { get; set; }
        public List<CheckBoxTable> MedicineList { get; set; } = new List<CheckBoxTable>();
    }

    public class CheckBoxTable
    {
        public  int  Id { get; set; }
        public bool IsCheck { get; set; }
        public string MedicineName { get; set; }
    }
}
