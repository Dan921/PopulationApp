using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationApp.Models
{
    public class Country
    {
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public string Continent { get; set; }
        public string Capital { get; set; }
    }
}
