using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{
    internal class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
             new { departmentName = newDepartmentName });
        }

        public void DeleteDepartment(string newDepartmentName)
        {
            _connection.Execute("DELETE FROM DEPARTMENTS WHERE departments.Name = @departmentName",
                new { departmentName = newDepartmentName });
        }
    }
}
