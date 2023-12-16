using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Models
{
    public class MasterModels
    {
    }

    public class GetCity
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
    }
}
