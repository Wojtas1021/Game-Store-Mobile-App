using System.Runtime.Serialization;
using WcfGameStore.Model.Entities;
using WcfGameStore.Utils;

namespace WcfGameStore.ViewModel
{
    [DataContract]
    public class EmployeeForView
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public EmployeeForView() { }
        //konstruktor mapujący
        public EmployeeForView(Employee employee)
        {
            PropertyUtils.AutomatedCopyingConstructor(this, employee);
        }
        public static implicit operator Employee(EmployeeForView employee)
        {
            var res = new Employee();
            res.AutomatedCopyingConstructor(employee);
            return res;
        }

        public static implicit operator EmployeeForView(Employee employee)
        {
            var res = new EmployeeForView();
            res.AutomatedCopyingConstructor(employee);
            return res;
        }
    }
}