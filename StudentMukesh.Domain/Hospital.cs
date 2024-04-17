using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Domain
{
    public class Hospital
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string? HospitalImage { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

    }
}
