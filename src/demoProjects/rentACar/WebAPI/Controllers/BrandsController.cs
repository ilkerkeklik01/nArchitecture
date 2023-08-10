using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            CreatedBrandDto result = await Mediator.Send(command);
            return Created("",result);
        }

        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery query = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getbyid={Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery query)
        {
               
            var result = await Mediator.Send(query);

            return Ok(result);
        }




    }
}
