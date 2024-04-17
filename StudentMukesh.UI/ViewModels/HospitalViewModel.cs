using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.UI.ViewModels
{
    public class HospitalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile? ChooseHospitalImage { get; set; }
        public string? HospitalImage { get; set; }
    }
}
