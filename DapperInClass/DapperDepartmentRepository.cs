using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace DapperInClass
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        // Field or local variable for making queries to the DB
        private readonly IDbConnection _connection;
        //Constructor
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

    }
}
