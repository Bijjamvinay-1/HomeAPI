using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bijjam_API.Controllers
{
    
    //[Route("api/[controller]")]
    [Route("api/HomeAPI")]
    [ApiController]

    public class HomeAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult< IEnumerable<HomeDTO>> GetHomes() 
        {
            return Ok(HomeStore.HomeList);
       
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(HomeDTO))]
   
        public ActionResult<HomeDTO> GetHome(int id) 
        {
            if (id == 0) 
            {
                return BadRequest();
            
            }
            var Home = HomeStore.HomeList.FirstOrDefault(u => u.Id == id);
            if (Home == null)
            { 
                return NotFound();  
            }

            return Ok(Home);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HomeDTO> CreateHome([FromBody]HomeDTO homeDto)
        
        {
            if (homeDto == null)
            { 
                return BadRequest();
            }
            if (homeDto.Id > 0)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError); 
            }
            //incrementing ID
            homeDto.Id = HomeStore.HomeList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            
            HomeStore.HomeList.Add(homeDto);    


            return Ok(homeDto); 

           

        }


    }
}
