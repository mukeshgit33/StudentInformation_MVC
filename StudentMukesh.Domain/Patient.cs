using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Domain
{
    public class Patient
    {
        public int Id { get; set; } //PK
        public string Name { get; set; }
        
        public ICollection<PatientMedicine> PatientMedicines { get; set; }=new HashSet<PatientMedicine>();

    }
}
