using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;

namespace Travel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterServiceRL _masterServiceRL;

        public MasterController(IMasterServiceRL masterServiceRL)
        {
            _masterServiceRL = masterServiceRL;
        }

        [HttpGet("GetData")]
        public ActionResult GetAllData(int cityId)
        {
            try
            {
                var result = _masterServiceRL.GetCityDetails(cityId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Details Fetched Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Details Could Not Be Fetched" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
