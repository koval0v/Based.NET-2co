using SWDevNet_KovalVadym_IS01_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWDevNet_KovalVadym_IS01_1
{
    public enum EmployeeState
    {
        HallController,
        Cashier,
        Cleaner,
        Administrator
    }

    public class Employee
    {
        private int idCardNumber;
        public int IDCardNumber
        {
            set
            {
                if (value.ToString().Length != 7)
                    throw new WrongEmployeeInfoException("ID card number must be 7 digits");
                else
                    idCardNumber = value;
            }
            get { return idCardNumber; }
        }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        private int age;
        public int Age
        {
            set
            {
                if (value < 18 || value > 60)
                    throw new WrongEmployeeInfoException("Age must be between 18 and 60");
                else
                    age = value;
            }
            get { return age; }
        }
        public EmployeeState EmployeeState { get; set; }

        public Employee(int idCardNumber, string name, string surname, string patronymic, int age, EmployeeState employeeState)
        {
            IDCardNumber = idCardNumber;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Age = age;
            EmployeeState = employeeState;
        }

    }

}
