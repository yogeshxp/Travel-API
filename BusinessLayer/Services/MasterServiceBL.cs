using BusinessLayer.Interface;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class MasterServiceBL : IMaterServiceBL
    {
        private readonly IMasterServiceRL _masterServiceRL;
        public MasterServiceBL(IMasterServiceRL masterServiceRL)
        {
            _masterServiceRL = masterServiceRL;
        }

        public Task<List<Cities>> GetAllCities()
        {
            try
            {
                return _masterServiceRL.GetAllCities();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<CityDetail>> GetCityDetails(int CityId)
        {
            try
            {
                return _masterServiceRL.GetCityDetails(CityId);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
