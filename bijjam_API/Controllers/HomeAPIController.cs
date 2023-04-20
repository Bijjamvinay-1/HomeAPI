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
        public async Task<ActionResult< IEnumerable<HomeDTO>>>GetHomes() 
        {
           
            return Ok(await _db.Homes.ToListAsync());
       
        }

        [HttpGet("{id:int}",Name = "GetHome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(HomeDTO))]
   
        public async Task<ActionResult<HomeDTO>> GetHome(int id) 
        {
            if (id == 0) 
            {
               
                return BadRequest();
            
            }
            var Home = await _db.Homes.FirstOrDefaultAsync(u => u.Id == id);
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
        public async Task<ActionResult<HomeDTO>> CreateHome([FromBody] HomeCreateDTO homeDto)

        {
            //    if (!ModelState.IsValid)
            //    { 
            //        return BadRequest(ModelState);  
            //    }

            if (await _db.Homes.FirstOrDefaultAsync(u => u.Name.ToLower() == homeDto.Name.ToLower()) != null)
            {

                ModelState.AddModelError(" ", "Home Alredy Exists!");
                return BadRequest(ModelState);
            
            }
            if (homeDto == null)
            {
                return BadRequest();
            }
            //if (homeDto.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            //incrementing ID
            Home modle = new ()
            { 
                Amenity = homeDto.Amenity, 
                Details = homeDto.Details,
                //Id = homeDto.Id,
                ImageUrl = homeDto.ImageUrl,    
                Name = homeDto.Name,    
                Occupancy = homeDto.Occupancy,  
                Rate = homeDto.Rate,
                Sqft = homeDto.Sqft,    
            };
            await _db.Homes.AddAsync(modle);
            await _db.SaveChangesAsync();  
            //return Ok(homeDto);    


          return CreatedAtRoute("GetHome", new { id = modle.Id }, modle);



        }
        
        [HttpDelete("{id:int}", Name = "DeleteHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes. Status400BadRequest)]
        public async Task<ActionResult <HomeDTO>> DeleteHome(int id) 
        {
            if (id == 0)
            {
                return BadRequest();
               

            }
            var home = await _db.Homes.FirstOrDefaultAsync(u => u.Id == id);
            if (home == null)
            { 
            return NotFound();  
            
            }
            _db.Homes.Remove(home); 
            await _db.SaveChangesAsync();
            return NoContent(); // return ok() //using NoContent we can remove undocumented
        
        
        }
        [HttpPut("{id:int}", Name = "UpdateHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateHome(int id , [FromBody]HomeUpdateDTO homeDTO) 
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
            await _db.SaveChangesAsync();
             return NoContent();



        }
        [HttpPatch("{id:int}", Name = "UpdatePartialHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialHome(int id, JsonPatchDocument<HomeUpdateDTO> patchDTO) 
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            
            }
            var home = await _db.Homes.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            HomeUpdateDTO homeDTO = new()
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
            await _db.SaveChangesAsync();
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




