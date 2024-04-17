using StudentMukesh.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Interfaces
{
    public interface IHospital
    {
        Task<IEnumerable<Hospital>> GetAll();
        Task <Hospital> Get(int id);
        Task Save(Hospital hospital);   
        Task Update(Hospital hospital); 
        Task Delete(int id);

    }
}
