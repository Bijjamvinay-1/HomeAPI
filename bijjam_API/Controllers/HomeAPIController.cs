using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Model.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bijjam_API.Controllers
{
    
    //[Route("api/[controller]")]
    [Route("api/HomeAPI")]
    [ApiController] // validation

    public class HomeAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult< IEnumerable<HomeDTO>> GetHomes() 
        {
            return Ok(HomeStore.HomeList);
       
        }

        [HttpGet("{id:int}",Name = "GetHome")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HomeDTO> CreateHome([FromBody] HomeDTO homeDto)

        {
            //    if (!ModelState.IsValid)
            //    { 
            //        return BadRequest(ModelState);  
            //    }

            if (HomeStore.HomeList.FirstOrDefault(u => u.Name.ToLower() == homeDto.Name.ToLower()) != null)
            {

                ModelState.AddModelError(" ", "Home Alredy Exists!");
                return BadRequest(ModelState);
            
            }
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
            //return Ok(homeDto);    


           return CreatedAtRoute("GetHome", new { id = homeDto.Id }, homeDto);



        }
        
        [HttpDelete("{id:int}", Name = "DeleteHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes. Status400BadRequest)]
        public ActionResult <HomeDTO> DeleteHome(int id) 
        {
            if (id == 0)
            {
                return BadRequest();
               

            }
            var home = HomeStore.HomeList.FirstOrDefault(u => u.Id == id);
            if (home == null)
            { 
            return NotFound();  
            
            }
            HomeStore.HomeList.Remove(home);    
            return NoContent(); // return ok() //using NoContent we can remove undocumented
        
        
        }
        [HttpPut("{id:int}", Name = "UpdateHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdateHome(int id , [FromBody]HomeDTO homeDTO) 
        {

            if (homeDTO == null || id != homeDTO.Id)
            {
                return BadRequest();
            
            }
            var home = HomeStore.HomeList.FirstOrDefault(u => u.Id == id);
            home.Name = homeDTO.Name;
            home.Sqft = homeDTO.Sqft;
            home.Occupancy = homeDTO.Occupancy;
            return NoContent();


        }
        [HttpPatch("{id:int}", Name = "UpdatePartialHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult UpdatePartialHome(int id, JsonPatchDocument<HomeDTO> patchDTO) 
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            
            }
            var home = HomeStore.HomeList.FirstOrDefault(u => u.Id == id);
            if (home == null)
            { 
                return BadRequest();    
            
            }
            patchDTO.ApplyTo(home, ModelState); // if any error we can store in modelsate

            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            
            }
            return NoContent();

            // to perform op reffer to https://jsonpatch.com/ 


        }




    }
}




