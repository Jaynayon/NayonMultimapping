using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExer3.Models;

namespace DapperExer3.Repositories
{
    internal interface IDepartmentRepository
    {
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}
