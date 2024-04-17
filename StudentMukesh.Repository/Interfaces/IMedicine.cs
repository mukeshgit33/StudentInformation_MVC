using StudentMukesh.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Interfaces
{
    public interface IMedicine
    {
       Task<IEnumerable<Medicine>> GetAll();
       Task <Medicine> Get(int id);
       Task Save(Medicine hospital);
       Task Update(Medicine hospital);
       Task Delete(int id);
    }
}
