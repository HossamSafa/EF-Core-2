using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    internal class Aircraft
    {
        public int Id {  get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }

        public int AirlineId { get; set; }
        public Airline Airline { get; set; }

        public ICollection<AircraftRoute> AircraftRoutes { get; set; } = new HashSet<AircraftRoute>();
    }
}
