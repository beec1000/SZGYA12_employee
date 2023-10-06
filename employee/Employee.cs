using System;
using System.Collections.Generic;
using System.Text;


namespace employee
{
    class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public string Marital_Status { get; set; }
        public int Salary { get; set; }//EUR

        public void kiir()
        {
            Console.WriteLine($"Neve: {Name}, Életkor: {Age}, Város: {City}, Osztály: {Department}, Beosztás: {Position}, Nem: {Gender}, Családi Állapot: {Marital_Status}, Fizetés: {Salary}EUR");
        }

        public Employee(string s)
        {
            var temp = s.Split(';');
            this.Name = temp[0];
            this.Age = Convert.ToInt32(temp[1]);
            this.City = temp[2];
            this.Department = temp[3];
            this.Position = temp[4];
            this.Gender = temp[5];
            this.Marital_Status = temp[6];
            this.Salary = Convert.ToInt32(temp[7]);
        }
    }
}
