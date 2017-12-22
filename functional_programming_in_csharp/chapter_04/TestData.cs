using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using System.Collections.Generic;
using System.Linq;

namespace chapter_04
{
    public static class TestData
    {
        public static Dictionary<string, Employee> GetEmployees()
        {
            var employees = new Dictionary<string, Employee>();
            var employee = new Employee
            {
                WorkPermit = new WorkPermit { Expiry = new DateTime(2011, 1, 1) },
                JoinedOn = new DateTime(1995, 4, 1),
                LeftOn = new DateTime(2017, 9, 1)
            };
            employees.Add("Tom", employee);

            employee = new Employee()
            {
                WorkPermit = new WorkPermit { Expiry = new DateTime(2080, 1, 1) },
                JoinedOn = new DateTime(1995, 4, 1),
                LeftOn = None
            };
            employees.Add("Bill", employee);

            employee = new Employee()
            {
                WorkPermit = new WorkPermit { Expiry = new DateTime(2080, 1, 1) },
                JoinedOn = new DateTime(2012, 10, 29),
                LeftOn = new DateTime(2017, 9, 1)
            };
            employees.Add("Nathan", employee);

            return employees;
        }
    }

    public class Employee
    {

        public string Id { get; set; }
        public Option<WorkPermit> WorkPermit { get; set; }
        public DateTime JoinedOn { get; set; }
        public Option<DateTime> LeftOn { get; set; }
    }

    public struct WorkPermit
    {
        public string Number { get; set; }
        public DateTime Expiry { get; set; }
    }
}