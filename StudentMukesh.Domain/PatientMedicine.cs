using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Domain
{
    public class PatientMedicine
    {

        public int PatientId { get; set; }  // FK
        public Patient Patient { get; set; }
        public int MedicineId { get; set; }  //FK
        public Medicine Medicine { get; set; }
         

    }
}

//Country   State(CountryId)    City(StateId)(CountryId)

// Patient            Medicine                   PatientMedicine

//1 Tarun  salary              1. Paracetamol             {1,1}{1,3} {2,2}{3,2}{3,3}        
//2. Ramesh 0           2. Dicnlofinec
//3. Suresh 0           3.  Citadol
//PatientMedicine
//{1,3}
//{1,1}
//{1,2 }
//{2,1}