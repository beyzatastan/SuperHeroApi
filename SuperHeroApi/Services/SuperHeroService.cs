using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
namespace SuperHeroApi.Services;

public class SuperHeroService: ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<SuperHero>> GetAllSuperHeros()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<SuperHero>? GetSingleHeroes(int id)
    {
       var hero =  await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
           return null;
        return hero;
    }

    public async Task<List<SuperHero>>? AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<List<SuperHero>>? UpdateHero(int id, SuperHero request)
    {
        var hero =  await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
            return null;
           
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;
        hero.Name = request.Name;
        
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }

    public  async Task<List<SuperHero>>?  DeleteHero(int id)
    {
        var hero =  await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
            return null;
           
        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        return await _context.SuperHeroes.ToListAsync();
    }
}