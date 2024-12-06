using SuperHeroApi.Models;

namespace SuperHeroApi.Services;

public interface ISuperHeroService
{
    Task<List<SuperHero>>? GetAllSuperHeros();
    Task<SuperHero>? GetSingleHeroes(int id);
    Task<List<SuperHero>>? AddHero(SuperHero hero);
    Task<List<SuperHero>>? UpdateHero(int id, SuperHero request);
    Task<List<SuperHero>>? DeleteHero(int id);
}