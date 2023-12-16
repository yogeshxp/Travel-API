using Microsoft.Data.SqlClient;
using RepositoryLayer.DataContext;
using RepositoryLayer.Models.ServiceStoreProcedure.MasterServices.IMasterDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Models.ServiceStoreProcedure.MasterServices.MasterDb
{
    public class MasterDb : IMasterDbInterface
    {
        private readonly MasterDbContext _context;

        public MasterDb(MasterDbContext context)
        {
            _context = context;
        }


        public virtual async Task<List<GetAllCityResult>> GetAllCityAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetAllCityResult>("EXEC @returnValue = [dbo].[GetAllCity]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }


        public virtual async Task<List<GetCityResult>> GetCityAsync(long? CityId, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "CityId",
                    Value = CityId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.BigInt,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetCityResult>("EXEC @returnValue = [dbo].[GetCity] @CityId", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

    }
}
