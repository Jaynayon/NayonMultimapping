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
    internal class CollegeRepository : ICollegeRepository
    {
        private readonly DapperContext _dapperContext;

        public CollegeRepository()
        {
            _dapperContext = new DapperContext("Data Source=COMPUTER-PC;Initial Catalog=Exer3Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

        public Task<IEnumerable<College>> GetAllColleges()
        {
            return (Task<IEnumerable<College>>)Task.Run(() =>
            {
                var sql = "SELECT ID,NAME,DEAN,THEME FROM College";
                using (var connection = _dapperContext.CreateConnection())
                {
                    return connection.Query<College>(sql);
                }
            });
        }

        public Task<College> GetCollege(int id)
        {
            return (Task<College>)Task.Run(() =>
            {
                var sql = "SELECT ID,NAME,DEAN,THEME FROM College WHERE ID = @id";
                using (var connection = _dapperContext.CreateConnection())
                {
                    return connection.QuerySingleOrDefault<College>(sql, new { id });
                }
            });
        }
    }
}
