using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExer3.Models;

namespace DapperExer3.Repositories
{
    internal interface ICollegeRepository
    {
        Task<College> GetCollege(int id);
        Task<IEnumerable<College>> GetAllColleges();
    }
}
