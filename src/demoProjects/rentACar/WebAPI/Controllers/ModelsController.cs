using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest request)
        {
            GetListModelQuery getListModelQuery = new() {PageRequest = request};

            ModelListModel result = await Mediator.Send(getListModelQuery);
            
            return Ok(result);
        }

    }
}
