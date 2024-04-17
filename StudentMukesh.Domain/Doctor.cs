using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Domain
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HospitalId { get; set; } //Foriegn Key
        public Hospital Hospital { get; set; }
    }
}
