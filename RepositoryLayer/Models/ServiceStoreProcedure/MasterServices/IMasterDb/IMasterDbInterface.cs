using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Models.ServiceStoreProcedure.MasterServices.IMasterDb
{
    public interface IMasterDbInterface
    {
        Task<List<GetCityResult>> GetCityAsync(long? CityId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
