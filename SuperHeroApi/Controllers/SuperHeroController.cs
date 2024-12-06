using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>>  GetAllHeroes()
        {
            return await _superHeroService.GetAllSuperHeros();
        }
        
        [HttpGet("{id}")]
        //[Route(("{id}"))]
        public async Task<IActionResult> GetSingleHeroes(int id)
        {
            var result = await _superHeroService.GetSingleHeroes(id);
            if(result is null)
                return NotFound("not found");
                
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            if(result is null)
                return NotFound("not found");
                
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero (int id, SuperHero request)
        { 
            var result = await _superHeroService.UpdateHero(id,request);
            if(result is null)
                return NotFound("not found");
                
            return Ok(result);
        }
         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero (int id)
        {
            var result =await _superHeroService.DeleteHero(id);
             if(result is null)
                return NotFound("not found");
                
            return Ok(result);
        }
    }
}