using CommonLayer.Models;
using Newtonsoft.Json;
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

        public async Task<List<CityDetail>> GetCityDetails(int CityId)
        {
            try
            {
                var data = await _masterDbInterface.GetCityAsync(CityId);
                List<CityDetail> getcity = data.AsEnumerable().Select(x => new CityDetail
                {
                    CityID = x.CityID,
                    CityName = x.CityName,
                    StateID = x.StateID,
                    StateName = x.StateName,
                    CityImages = JsonConvert.DeserializeObject<List<ImageDetail>>(x.cityDetails)

                }).ToList();

                return getcity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<Cities>> GetAllCities()
        {
            try
            {
                var data = await _masterDbInterface.GetAllCityAsync();
                List<Cities> getcity = data.AsEnumerable().Select(x => new Cities
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
