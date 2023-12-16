using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IMasterServiceRL
    {
        Task<List<GetCity>> GetCityDetails(int CityId);
    }
}
