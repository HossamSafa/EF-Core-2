using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.Models
{
    [PrimaryKey(nameof(AircraftId),nameof(RouteId))]
    internal class AircraftRoute
    {
        public int NumOfPassengers { get; set; }
        public decimal Price { get; set; }

        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Duration { get; set; }

        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        public int RouteId {  get; set; }

        public Route Route { get; set; }

    }
}
