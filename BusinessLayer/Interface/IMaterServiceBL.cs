﻿using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMaterServiceBL
    {
        Task<List<Cities>> GetAllCities();
        Task<List<CityDetail>> GetCityDetails(int CityId);

    }
}
