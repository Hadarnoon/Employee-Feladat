using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace employee2
{
    internal class Dolgozo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public bool MartialStatus { get; set; }
        public int Salary { get; set; }
        public int AnnualSalary { get; set; }
        public double AnnualSalaryInHuf { get; set; }

        public Dolgozo(string sor)
        {
            var v = sor.Split(';');
            this.Name = v[0];
            this.Age = int.Parse(v[1]);
            this.City = v[2];
            this.Department = v[3];
            this.Position = v[4];
            this.Gender = v[5] == "Male";
            this.MartialStatus = v[6] == "Married";
            this.Salary = int.Parse(v[7]);
            this.AnnualSalary = this.Salary * 12;
            this.AnnualSalaryInHuf = this.AnnualSalary * 380;
        }

        public override string ToString()
        {
            return $"{Name} | {Age} éves| {City} | {Department} | {Position} | {(Gender ? "Male" : "Female")} | {(MartialStatus ? "Married" : "Single")} | {Salary} euró havonta | {AnnualSalary} euró évente";
        }
    }
}
