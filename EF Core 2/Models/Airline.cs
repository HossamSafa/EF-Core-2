using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    internal class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public ICollection<Aircraft> Aircrafts { get; set; } = new HashSet<Aircraft>();

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
