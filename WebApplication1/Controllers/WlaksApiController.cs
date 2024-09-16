using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.CustomActionFilter;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositiory;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]     //The placeholder [controller] is automatically replaced with the name of the controller class without the "Controller" suffix
    [ApiController]
    
    public class WlaksApiController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walksrepo;

        public WlaksApiController(IMapper mapper, IWalkRepository walksrepo)
        {
            this.mapper = mapper;
            this.walksrepo = walksrepo;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkrequestDto)
        {
            //if (ModelState.IsValid)
            //{
                var walkdomainmodel = mapper.Map<Walk>(addWalkrequestDto);
                await walksrepo.CreateAsync(walkdomainmodel);
                return Ok(mapper.Map<WalksDto>(walkdomainmodel));
            //}
            //else
            //{
            //    return BadRequest();
            //}
            

        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool ? isAscending, [FromQuery] int pageNumber=1, [FromQuery] int pageSize=1000)
        {
            var walksDomainModel = await walksrepo.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true, pageNumber,pageSize);
            throw new Exception("This is new Exception"); 
            return Ok(mapper.Map<List<WalksDto>>(walksDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkdomainmodel=await walksrepo.GetByIdAsync(id);
            if(walkdomainmodel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDto>(walkdomainmodel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            //if (updateWalkRequestDto == null)
            //{
            //    return BadRequest("Invalid data.");
            //}

            //if (ModelState.IsValid)
            //{
                var walkdomainmodel = mapper.Map<Walk>(updateWalkRequestDto);
                walkdomainmodel = await walksrepo.UpdateAsync(id, walkdomainmodel);
                if (walkdomainmodel == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<WalksDto>(walkdomainmodel));
            //}
            //else
            //{
            //    return BadRequest();
            //}
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedomainmodel= await walksrepo.DeleteAsync(id);
            if (deletedomainmodel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDto>(deletedomainmodel));
        }

    }
}
