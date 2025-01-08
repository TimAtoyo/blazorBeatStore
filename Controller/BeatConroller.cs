using EcommerseBlazor.Models;
using EcommerseBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerseBlazor.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BeatController(IBeatService beatService) : Controller 
    {
        private readonly IBeatService _beatService = beatService;

        // [HttpPost("CreateBeat")]
        // public async Task<IActionResult> CreateBeat(Beat beat){
        //     var newBeat = await _beatService.CreateBeatAsync(beat);
        //     return Ok(newBeat);
        // }
    }
}