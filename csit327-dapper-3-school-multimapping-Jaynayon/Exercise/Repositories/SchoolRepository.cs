using System.Data;
using Dapper;
using DapperExer3.Context;
using DapperExer3.Models;

namespace DapperExer3.Repositories
{
    internal class SchoolRepository : ISchoolRepository
    {
        private readonly DapperContext _dapperContext;

        public SchoolRepository()
        {
            _dapperContext = new DapperContext("Data Source=COMPUTER-PC;Initial Catalog=Exer3Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }

        public Task<IEnumerable<School>> GetAllSchools()
        {
            return (Task<IEnumerable<School>>)Task.Run(() =>
            {
                var sql = "SELECT * FROM School a INNER JOIN College b ON a.Id = b.SchoolId " +
                "INNER JOIN Department c on b.Id = c.CollegeId";
                using (var connection = _dapperContext.CreateConnection())
                {
                    var schl = connection.Query<School, College, Department, School>(sql, (school, college, department) =>
                    {
                        college.Department.Add(department); //Maps List<Department> to College
                        school.College.Add(college); //Maps List<College> to School
                        return school;
                    });

                    return schl.GroupBy(s => s.Id).Select(g =>
                    {
                        var first = g.First();
                        first.College = g.SelectMany(school => school.College).ToList();

                        return first;
                    });
                }
             });
        }

        public Task<School> GetSchool(int id)
        {
            return (Task<School>)Task.Run(() =>
            {
                var sql = "SELECT * FROM School WHERE ID = @id";
                using (var connection = _dapperContext.CreateConnection())
                {
                    return connection.QuerySingleOrDefault<School>(sql, new { id });
                }
            });
        }
    }
}
