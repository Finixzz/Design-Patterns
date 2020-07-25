using FactoryDemo.Managers;
using FactoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryDemo.Factory
{
    public class EmployeeManagerFactory
    {
        private IEmployeeManager GetEmployeeManager(int EmployeeTypeId)
        {
            IEmployeeManager manager = null;
            if (EmployeeTypeId == 1)
            {
                manager = new PermanentEmployeeManager();
            }else if (EmployeeTypeId == 2)
            {
                manager = new ContractEmployeeManager();
            }
            return manager;
        }

        public void ApplyHourlyPayAndBonus(Employee newEmployee)
        {
            IEmployeeManager manager = GetEmployeeManager(newEmployee.EmployeeTypeId);
            newEmployee.HourlyPay = manager.GetPay();
            newEmployee.Bonus = manager.GetBonus();
        }
    }
}
