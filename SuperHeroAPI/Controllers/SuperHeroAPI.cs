using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroAPI : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroAPI(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(await _context.SuperHeros.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHeros(SuperHero hero)
        {
            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateSuperHeros(SuperHero hero)
        {
            var dbHero = await _context.SuperHeros.FindAsync(hero.Id);
            if (dbHero == null)
                return BadRequest("hero not found");
            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHeros(int id)
        {
            var dbHero = await _context.SuperHeros.FindAsync(id);
            if (dbHero == null)
                return BadRequest("hero not found");
            _context.SuperHeros.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }
    }
}
