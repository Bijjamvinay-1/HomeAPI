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
    [Route("api/HomeNumberAPI")]


    public class HomeNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IHomeNumberRepository _dbHomeNumber;
        private readonly IMapper _mapper;
        public HomeNumberAPIController(IHomeNumberRepository dbHomeNumber, IMapper mapper)
        {
            _dbHomeNumber = dbHomeNumber;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetHomeNumbers()
        {
            try
            {
                IEnumerable<HomeNumber> homeNumberlist = await _dbHomeNumber.GetAllAsync();
                //Here we are mapping Home To HomeDto
                _response.Result = _mapper.Map<List<HomeNumberDTO>>(homeNumberlist);
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

        [HttpGet("{id:int}", Name = "GetHomeNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(HomeDTO))]

        public async Task<ActionResult<APIResponse>> GetHomeNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);

                }
                var HomeNumber = await _dbHomeNumber.GetAsync(u => u.HomeNo == id);
                if (HomeNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }


                _response.Result = _mapper.Map<HomeNumberDTO>(HomeNumber);
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
        public async Task<ActionResult<APIResponse>> CreateHomeNumber([FromBody] HomeNumberCreateDTO createDTO)

        {
            
            try
            {
                if (await _dbHomeNumber.GetAsync(u => u.HomeNo == createDTO.HomeNo) !=null)
                {

                    ModelState.AddModelError(" CustomError", "Home number Alredy Exists!");
                    return BadRequest(ModelState);

                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
               

                HomeNumber HomeNumber = _mapper.Map<HomeNumber>(createDTO);
                
                await _dbHomeNumber.CreateAsync(HomeNumber);
                //return Ok(homeDto);    
                _response.Result = _mapper.Map<HomeNumberDTO>(HomeNumber);
                _response.StatusCode = HttpStatusCode.Created;


                return CreatedAtRoute("GetHome", new { id = HomeNumber.HomeNo }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}", Name = "DeleteHomeNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> DeleteHomeNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();


                }
                var homeNumber = await _dbHomeNumber.GetAsync(u => u.HomeNo == id);
                if (homeNumber == null)
                {
                    return NotFound();

                }
                await _dbHomeNumber.RemoveAsync(homeNumber);

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
        [HttpPut("{id:int}", Name = "UpdateHomeNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> UpdateHomeNumber(int id, [FromBody] HomeNumberUpdateDTO UpdateDTO)
        {
            try
            {
                if (UpdateDTO == null || id != UpdateDTO.HomeNo)
                {
                    return BadRequest();

                }
                HomeNumber model = _mapper.Map<HomeNumber>(UpdateDTO);
                
                await _dbHomeNumber.UpdateAsync(model);
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
        




    }
}




