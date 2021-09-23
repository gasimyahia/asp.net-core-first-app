using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementMVC.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _eployeeList;

        public MockEmployeeRepository()
        {
            _eployeeList = new List<Employee>()
            {
                new Employee(){id=1,Name="ahmed ali",Email="ahmend@gmail.com",Department=Dept.HR},
                new Employee(){id=2,Name="omer ali",Email="omer@gmail.com",Department=Dept.IT}
            };
        }

        public IEnumerable<Employee> getAllEmployee()
        {
            return _eployeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _eployeeList.FirstOrDefault(e => e.id == id);
        }
    }
}
