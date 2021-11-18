using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using R2S.Training.Entities;
using System.Data;
namespace R2S.Training.Dao
{
    interface IEmployeeDAO
    {
        List<Employee> getAllEmployee();

        Employee getEmployeeById(int employee_id);

        bool addEmployee(Employee employee);

        bool updateEmployee(Employee employee);

    }
}
