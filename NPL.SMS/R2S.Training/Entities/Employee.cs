using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2S.Training.Entities
{
    class Employee
    {
        private int employeeId;
        private String employeeName;
        private double salary;
        private int spvrId;

        public Employee(int EmployeeId, String EmployeeName, double Salary, int SpvrId)
        {
            this.employeeId = EmployeeId;
            this.employeeName = EmployeeName;
            this.salary = Salary;
            this.spvrId = SpvrId;
        }

        public int getEmployeeId()
        {
            return this.employeeId;
        }
        public void setEmployeeId(int EmployeeId)
        {
            this.employeeId = EmployeeId;
        }

        public String getEmployeeName()
        {
            return this.employeeName;
        }
        public void setEmployeeName(String EmployeeName)
        {
            this.employeeName = EmployeeName;
        }

        public double getSalary()
        {
            return this.salary;
        }
        public void setSalary(double Salary)
        {
            this.salary = Salary;
        }

        public int getSpvrId()
        {
            return this.spvrId;
        }
        public void setSpvrId(int SpvrId)
        {
            this.spvrId = SpvrId;
        }
    }
}
