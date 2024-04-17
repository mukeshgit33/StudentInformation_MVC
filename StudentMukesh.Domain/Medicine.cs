using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Domain
{
    // medicine(1)---------(*)PatientMedicine(*)---------(1)Patient
    public class Medicine
    {
        public int Id { get; set; }  //PK
        public string Name { get; set; }

        public ICollection<PatientMedicine> PatientMedicines { get; set; } = new HashSet<PatientMedicine>();
    }
}
