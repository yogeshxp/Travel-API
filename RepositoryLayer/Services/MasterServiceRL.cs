using CommonLayer.Models;
using RepositoryLayer.Interface;
using RepositoryLayer.Models.ServiceStoreProcedure.MasterServices.IMasterDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class MasterServiceRL : IMasterServiceRL
    {
        private readonly IMasterDbInterface _masterDbInterface;

        public MasterServiceRL(IMasterDbInterface masterDbInterface)
        {
            _masterDbInterface = masterDbInterface;   
        }

        public async Task<List<GetCity>> GetCityDetails(int CityId)
        {
            try
            {
                var data = await _masterDbInterface.GetCityAsync(CityId);
                List<GetCity> getcity = data.AsEnumerable().Select(x => new GetCity
                {
                    CityID = x.CityID,
                    CityName = x.CityName,
                    StateID = x.StateID,
                    StateName = x.StateName,
                    CountryID = x.CountryID,
                    CountryName = x.CountryName
                }).ToList();

                return getcity;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
