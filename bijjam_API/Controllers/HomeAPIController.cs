using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;


namespace bijjam_API.Controllers
{
   
    [ApiController]
    [Route("api/HomeAPI")]
    

    public class HomeAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HomeAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult< IEnumerable<HomeDTO>> GetHomes() 
        {
           
            return Ok(_db.Homes.ToList());
       
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
            var Home = _db.Homes.FirstOrDefault(u => u.Id == id);
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

            if (_db.Homes.ToList().FirstOrDefault(u => u.Name.ToLower() == homeDto.Name.ToLower()) != null)
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
            Home modle = new ()
            { 
                Amenity = homeDto.Amenity, 
                Details = homeDto.Details,
                Id = homeDto.Id,
                ImageUrl = homeDto.ImageUrl,    
                Name = homeDto.Name,    
                Occupancy = homeDto.Occupancy,  
                Rate = homeDto.Rate,
                Sqft = homeDto.Sqft,    
            };
            _db.Homes.Add(modle);
            _db.SaveChanges();  
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
            var home = _db.Homes.FirstOrDefault(u => u.Id == id);
            if (home == null)
            { 
            return NotFound();  
            
            }
            _db.Homes.Remove(home); 
            _db.SaveChanges(true);
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
            Home modle = new()
            {
                Amenity = homeDTO.Amenity,
                Details = homeDTO.Details,
                Id = homeDTO.Id,
                ImageUrl = homeDTO.ImageUrl,
                Name = homeDTO.Name,
                Occupancy = homeDTO.Occupancy,
                Rate = homeDTO.Rate,
                Sqft = homeDTO.Sqft,
            };
            _db.Homes.Update(modle);
            _db.SaveChanges();
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
            var home = _db.Homes.AsNoTracking().FirstOrDefault(u => u.Id == id);

            HomeDTO homeDTO = new()
            {
                Amenity = home.Amenity,
                Details = home.Details,
                Id = home.Id,
                ImageUrl = home.ImageUrl,
                Name = home.Name,
                Occupancy = home.Occupancy,
                Rate = home.Rate,
                Sqft = home.Sqft,
            };


            if (home == null)
            { 
                return BadRequest();    
            
            }
            patchDTO.ApplyTo(homeDTO, ModelState); // if any error we can store in modelsate
            Home modle = new Home()
            {
                Amenity = homeDTO.Amenity,
                Details = homeDTO.Details,
                Id = homeDTO.Id,
                ImageUrl = homeDTO.ImageUrl,
                Name = homeDTO.Name,
                Occupancy = homeDTO.Occupancy,
                Rate = homeDTO.Rate,
                Sqft = homeDTO.Sqft,
            };
            _db.Homes.Update(modle);
            _db.SaveChanges();
            return NoContent();

            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            
            }
            return NoContent();

            // to perform op reffer to https://jsonpatch.com/ 


        }




    }
}




