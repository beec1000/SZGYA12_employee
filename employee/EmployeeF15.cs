using System;
using System.Collections.Generic;
using System.Text;


namespace employee
{
    class EmployeeF15
    {
        public string NameF15 { get; set; }
        public int SalaryF15 { get; set; }

        public void kiirF15()
        {
            Console.WriteLine($"Neve: {NameF15}, Fizetés: {SalaryF15}EUR");
        }


        public EmployeeF15(string s)
        {
            var temp = s.Split(';');
            this.NameF15 = temp[0];
            this.SalaryF15 = Convert.ToInt32(temp[7]);
        }
    }
}
