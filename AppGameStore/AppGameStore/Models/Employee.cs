using AppGameStore.Utils;
using ServiceReferenceGameStore;

namespace AppGameStore.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Employee() { }
        public Employee(EmployeeForView employee)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, employee);
        }

        public static implicit operator EmployeeForView(Employee employee)
        {
            var res = new EmployeeForView();
            res.AutomatedCopyingConstructor(employee);
            return res;
        }
        public static implicit operator Employee(EmployeeForView employee)
        {
            var res = new Employee();
            res.AutomatedCopyingConstructor(employee);
            return res;
        }
    }
}
