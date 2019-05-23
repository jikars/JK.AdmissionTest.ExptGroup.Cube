using JK.Cube.Application.Commands;
using JK.Cube.Application.Projections;
using JK.Cube.Application.Queries.Condtions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JK.Cube.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CubeController : CustomControllerBase
    {


        [HttpPost]
        [Route("createCube")]
        public bool CreateCube([Required][FromBody]int size)
        {
            return SendCommand(new CreateCubeCommand { Size = size }).Result;
        }

        [HttpPut]
        [Route("updateCube")]
        public bool UpdateCube([Required][FromBody] string id, [Required][FromBody]int x,
            [Required][FromBody]int y, [Required][FromBody]int z, [Required] [FromBody]long value)
        {
            return SendCommand(new UpdateCubeCommand { Id = id, Coordenate = new Application.DTO.Coordenate { X = x, Y = y, Z = z }, Value = value }).Result;
        }

        [HttpGet]
        [Route("queryCube")]
        public long Query([Required] string id, [Required]int x1, [Required]int y1,
            [Required]int z1, [Required]int x2, [Required]int y2, [Required]int z2) 
        {
            return QueryGetCondition<CubeQueryCondition, CubeProjection, long>(new CubeQueryCondition
            {
                Id = id,
                Coordenate1 = new Application.DTO.Coordenate { X = x1, Y = y1, Z = z1 },
                Coordenate2 = new Application.DTO.Coordenate { X = x2, Y = y2, Z = z2 }
            });
        }


        [HttpGet]
        [Route("getAll")]
        public IEnumerable<CubeProjection> GetAll()
        {
            return QueryGetAll<CubeQueryCondition, CubeProjection, long>();
        }


        [HttpGet]
        [Route("getById")]
        public CubeProjection GetById(string id)
        {
            return QueryGetById<CubeQueryCondition, CubeProjection, long>(id);
        }
    }
}