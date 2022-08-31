using AppGameStore.Models;
using ServiceReferenceGameStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppGameStore.Services
{
    public class EmployeeDataStore : AbstractDataStore<Employee>
    {
        public EmployeeDataStore()
            :base()
        {
            GameStoreServices.GetEmployees(new GetEmployeesRequest()).
                GetEmployeesResult
                .Select(k => new Employee(k))
                .ToList();

        }
        public override void Add(Employee item)
        {
            GameStoreServices.AddOrUpdateEmployee(new AddOrUpdateEmployeeRequest(item));
        }

        public override Employee Find(Employee item)
        {
            return items.FirstOrDefault(arg => arg.EmployeeID == item.EmployeeID);
        }
        public override Employee Find(int id)
        {
            return items.FirstOrDefault(arg => arg.EmployeeID == id);
        }

        public override void Refresh()
        {
            List<EmployeeForView> listaEFV =
                          GameStoreServices.GetEmployees(new GetEmployeesRequest())
                          .GetEmployeesResult
                          .ToList();
            items = new List<Employee>();
            foreach (var e in listaEFV)
            {
                items.Add(new Employee(e));
            }
        }
    }
}
