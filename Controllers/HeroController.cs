using HeroAPI.Data;
using HeroAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public HeroController(AppDBContext db)
        {
            this._dbContext = db;
        }

        [HttpGet]
        [Route("get-heroes")]
        public async Task<ActionResult<List<Hero>>> GetHeroes()
        {
            return await _dbContext.Heroes.ToListAsync();
        }

        [HttpGet]
        [Route("get-hero-by-id/{heroId}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var heroe = await _dbContext.Heroes.FindAsync(id);
            if (heroe == null) return BadRequest("Not found.");
            else return Ok(heroe);
        }

        [HttpPost]
        [Route("add-hero")]
        public async Task<ActionResult<bool>> AddHero(Hero hero)
        {
            try
            {
                await _dbContext.Heroes.AddAsync(hero);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        [Route("update-hero")]
        public async Task<ActionResult<bool>> UpdateHero(Hero hero)
        {
            try
            {
                _dbContext.Heroes.Update(hero);
                return await _dbContext.SaveChangesAsync() >= 1;
 
            }catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("delete-hero/{heroId}")]
        public async Task<ActionResult<bool>> DeleteHero(int id)
        {
            try
            {
                var heroe = await _dbContext.Heroes.FindAsync(id);
                _dbContext.Heroes.Remove(heroe);
                return await _dbContext.SaveChangesAsync() >= 1;
            }catch (Exception)
            {
                return false;
            }
        }


    }
}
