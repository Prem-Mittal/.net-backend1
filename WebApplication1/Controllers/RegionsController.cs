using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WebApplication1.CustomActionFilter;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTOs;
using WebApplication1.Repositiory;

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]     //telling to come on this page whenever this route is trigered i.e http://localhost:8080/api/regions
    [ApiController]                 //attribute
   
    public class RegionsController : ControllerBase
    {
        private readonly oneDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(oneDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)        //onedbcontext is dbcontext created and injected in container and we are accessing here i.e .net automatically provides
        {
               this.dbContext=dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()       //IActionResult: is a  return type  indicates that the method returns a result of an HTTP response.
        {
            //var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionsDomain = await regionRepository.GetAllAsync();
            //var regionsDto = new List<RegionDto>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageURL = region.RegionImageURL,
            //    });
            //}
            //or
            //var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
            //or
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]    // It specifies that the method should be called when a request matches the given URL pattern."{id:Guid}":  //api/regions/{id}
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var regionDomain=await dbContext.Regions.FindAsync(id);
            var regionDomain= await regionRepository.GetByIDAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //var regionsDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    RegionImageURL = regionDomain.RegionImageURL,

            //};
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto) 
        {
            
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //    RegionImageURL = addRegionRequestDto.RegionImageURL
                //};

                //await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //var regiondto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageURL = regionDomainModel.RegionImageURL
                //};

                var regiondto = mapper.Map<RegionDto>(regionDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regiondto);
            
           
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateregionsRequestDto updateregionsRequestDto)
        {
            //var regiondomainmodel=await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);

            //var regiondomainmodel = new Region
            //{
            //    Code = updateregionsRequestDto.Code,
            //    Name = updateregionsRequestDto.Name,
            //    RegionImageURL = updateregionsRequestDto.RegionImageURL
            //};
            //if (ModelState.IsValid) 
            //{
                var regiondomainmodel = mapper.Map<Region>(updateregionsRequestDto);
                regiondomainmodel = await regionRepository.UpdateAsync(id, regiondomainmodel);
                if (regiondomainmodel == null)
                {
                    return NotFound();
                }
                var regiondto = mapper.Map<RegionDto>(regiondomainmodel);
                return Ok(regiondto);
            //}
            //else
            //{
            //    return BadRequest(ModelState);
            //}
           
            //map dto to domain model
            //regiondomainmodel.Code=updateregionsRequestDto.Code;
            //regiondomainmodel.Name=updateregionsRequestDto.Name;
            //regiondomainmodel.RegionImageURL=updateregionsRequestDto.RegionImageURL;

            //await dbContext.SaveChangesAsync();

            //convert domain model to dto

            //var regiondto = new RegionDto
            //{
            //    Id = regiondomainmodel.Id,
            //    Code = regiondomainmodel.Code,
            //    Name = regiondomainmodel.Name,
            //    RegionImageURL = regiondomainmodel.RegionImageURL
            //};

           
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            var regionDomainModel= await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            // dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageURL = regionDomainModel.RegionImageURL

            };
            return Ok(regionDto);
        }
    }
}
