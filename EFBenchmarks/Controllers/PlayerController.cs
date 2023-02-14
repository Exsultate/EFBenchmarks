using Database.Model;
using EFBenchmarks.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EFBenchmarks.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;
    private IPlayerRepository _playerRepository;

    public PlayerController(ILogger<PlayerController> logger, IPlayerRepository playerRepository)
    {
        _logger = logger;
        _playerRepository = playerRepository;
    }

    [HttpGet("{playerId}")]
    public async Task<IResult> Get(Guid playerId)
    {
        var player = await _playerRepository.Get(playerId);

        return player == null ? Results.NotFound() : Results.Ok(player);
    }
    
    [HttpGet]
    public async Task<IResult> List()
    {
        var players = await _playerRepository.List();

        return players.Count == 0 ? Results.NotFound() : Results.Ok(players);
    }

    [HttpPost]
    public async Task<IResult> Create(Player player)
    {
        var createPlayer = await _playerRepository.Create(player);

        return createPlayer == null ? Results.Problem() : Results.Ok(createPlayer);
    }
}
