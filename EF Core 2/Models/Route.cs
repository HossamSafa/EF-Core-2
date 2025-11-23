using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    internal class Route
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Classification { get; set; }
        public decimal Distance { get; set; }

        public ICollection<AircraftRoute> AircraftRoutes { get; set; }=new HashSet<AircraftRoute>();
    }
}
