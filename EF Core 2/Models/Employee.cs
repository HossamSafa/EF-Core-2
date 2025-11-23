using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Qualification1 { get; set; }
        public string Qualification2 { get; set; }
        public string Qualification3 { get; set; }

        public string Address {  get; set; }

       public char Gender { get; set; }
        public string Position { get; set; }

        public int AirlineId { get; set; }

        public Airline Airline { get; set; }
    }
}
