using Microsoft.AspNetCore.Mvc;

namespace JK.Cube.Api.Controllers
{
    /// <summary>
    /// Api service access cube functionalities
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CubeController : ControllerBase
    {
        [HttpDelete("{id}")]
        public string Delete(long id)
        {


            return "';";
           
        }
    }
}