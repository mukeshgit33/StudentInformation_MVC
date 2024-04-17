using StudentMukesh.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Interface
{
    public interface IDoctor
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task <Doctor> GetById(int id);
        Task Save(Doctor doctor);
        Task DeleteById(int id);
        Task Update(Doctor doctor);

    }
}
