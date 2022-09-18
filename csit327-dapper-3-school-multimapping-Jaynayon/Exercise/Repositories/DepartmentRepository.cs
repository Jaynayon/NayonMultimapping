using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExer3.Context;
using DapperExer3.Models;

namespace DapperExer3.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _dapperContext;

        public DepartmentRepository()
        {
            _dapperContext = new DapperContext("Data Source=COMPUTER-PC;Initial Catalog=Exer3Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

        public Task<IEnumerable<Department>> GetAllDepartments()
        {
            return (Task<IEnumerable<Department>>)Task.Run(() =>
            {
                var sql = "SELECT ID,NAME,CHAIR FROM Department";
                using (var connection = _dapperContext.CreateConnection())
                {
                    return connection.Query<Department>(sql);
                }
            });
        }

        public Task<Department> GetDepartment(int id)
        {
            return (Task<Department>)Task.Run(() =>
            {
                var sql = "SELECT ID,NAME, CHAIR FROM Department WHERE ID = @id";
                using (var connection = _dapperContext.CreateConnection())
                {
                    return connection.QuerySingleOrDefault<Department>(sql, new { id });
                }
            });
        }
    }
}
