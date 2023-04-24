using AutoMapper;
using bijjam_API.Data;
using bijjam_API.Model;
using bijjam_API.Model.DTO;
using bijjam_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.Resource;
using System.Net;

namespace bijjam_API.Controllers                   //To Aline crt A , crt k+D
{

    [ApiController]
    [Route("api/HomeAPI")]


    public class HomeAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IHomeRepository _dbHome;
        private readonly IMapper _mapper;
        public HomeAPIController(IHomeRepository dbHome, IMapper mapper)
        {
            _dbHome = dbHome;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetHomes()
        {
            try
            {
                IEnumerable<Home> homelist = await _dbHome.GetAllAsync();
                //Here we are mapping Home To HomeDto
                _response.Result = _mapper.Map<List<HomeDTO>>(homelist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetHome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(HomeDTO))]

        public async Task<ActionResult<APIResponse>> GetHome(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);

                }
                var Home = await _dbHome.GetAsync(u => u.Id == id);
                if (Home == null)
                {
                    _response.StatusCode=HttpStatusCode.NotFound;
                    return NotFound(_response);
                }


                _response.Result = _mapper.Map<HomeDTO>(Home);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateHome([FromBody] HomeCreateDTO createDTO)

        {
            //    if (!ModelState.IsValid)
            //    { 
            //        return BadRequest(ModelState);  
            //    }
            try
            {
                if (await _dbHome.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {

                    ModelState.AddModelError(" ", "Home Alredy Exists!");
                    return BadRequest(ModelState);

                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                //if (homeDto.Id > 0)
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}
                //incrementing ID

                Home Home = _mapper.Map<Home>(createDTO);
                //Home modle = new ()
                //{ 
                //    Amenity = createDTO.Amenity, 
                //    Details = createDTO.Details,
                //    //Id = homeDto.Id,
                //    ImageUrl = createDTO.ImageUrl,    
                //    Name = createDTO.Name,    
                //    Occupancy = createDTO.Occupancy,  
                //    Rate = createDTO.Rate,
                //    Sqft = createDTO.Sqft,    
                //};
                await _dbHome.CreateAsync(Home);
                //return Ok(homeDto);    
                _response.Result = _mapper.Map<HomeDTO>(Home);
                _response.StatusCode = HttpStatusCode.Created;


                return CreatedAtRoute("GetHome", new { id = Home.Id }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "DeleteHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteHome(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();


                }
                var home = await _dbHome.GetAsync(u => u.Id == id);
                if (home == null)
                {
                    return NotFound();

                }
                await _dbHome.RemoveAsync(home);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response); // return ok() //using NoContent we can remove undocumented
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpPut("{id:int}", Name = "UpdateHome")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateHome(int id, [FromBody] HomeUpdateDTO UpdateDTO)
        {
            try
            {
                if (UpdateDTO == null || id != UpdateDTO.Id)
                {
                    return BadRequest();

                }
                Home model = _mapper.Map<Home>(UpdateDTO);
                //Home modle = new()
                //{
                //    Amenity = UpdateDTO.Amenity,
                //    Details = UpdateDTO.Details,
                //    Id = UpdateDTO.Id,
                //    ImageUrl = UpdateDTO.ImageUrl,
                //    Name = UpdateDTO.Name,
                //    Occupancy = UpdateDTO.Occupancy,
                //    Rate = UpdateDTO.Rate,
                //    Sqft = UpdateDTO.Sqft,
                //};
                await _dbHome.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;





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
            var home = await _dbHome.GetAsync(u => u.Id == id, tracked: false);

            HomeUpdateDTO homeDTO = _mapper.Map<HomeUpdateDTO>(home);
            // OR.................................
            //HomeUpdateDTO UpdateDTO = new()
            //{
            //    Amenity = home.Amenity,
            //    Details = home.Details,
            //    Id = home.Id,
            //    ImageUrl = home.ImageUrl,
            //    Name = home.Name,
            //    Occupancy = home.Occupancy,
            //    Rate = home.Rate,
            //    Sqft = home.Sqft,
            //};


            if (home == null)
            {
                return BadRequest();

            }
            patchDTO.ApplyTo(homeDTO, ModelState); // if any error we can store in modelsate
            Home model = _mapper.Map<Home>(homeDTO);
            //Or...................................
            //Home modle = new Home()
            //{
            //    Amenity = homeDTO.Amenity,
            //    Details = homeDTO.Details,
            //    Id = homeDTO.Id,
            //    ImageUrl = homeDTO.ImageUrl,
            //    Name = homeDTO.Name,
            //    Occupancy = homeDTO.Occupancy,
            //    Rate = homeDTO.Rate,
            //    Sqft = homeDTO.Sqft,
            //};
            await _dbHome.UpdateAsync(model);
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




