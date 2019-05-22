using JK.Core.Architecture.DDD.Persistence;
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
        public CubeController(IRepository<Domain.Models.Cube> Cube)
        {

        }

        [HttpDelete("{id}")]
        public string Delete(long id)
        {

            return "';";
           
        }
    }
}