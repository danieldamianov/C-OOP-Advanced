using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IList<Employee> employees = new List<Employee>()
            {
                new Employee("Pesho"),
                new Employee("Gosho"),
                new Manager("Dani",new string[]{ "Word","Excel","PowerPoint"}),
                new Manager("Yoana",new string[]{ "Word","Excel","PowerPoint"}),
            };
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
