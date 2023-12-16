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

    public class Cities
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
    }

    public class CityDetail
    {
        public int CityID { get; set; }
        public string? CityName { get; set; }
        public int? StateID { get; set; }
        public string? StateName { get; set; }
        public string? CityDetails { get; set; }
        public List<ImageDetail> CityImages { get; set; }
    }

    public class ImageDetail
    {
        public string Images { get; set; }
    }
}
