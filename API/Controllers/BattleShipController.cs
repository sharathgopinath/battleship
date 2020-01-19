using System;
using System.Net;
using API.ViewModels;
using Application.BattleShip.Interfaces;
using Application.Common.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/battle-ship")]
    [ApiController]
    public class BattleShipController : ControllerBase
    {
        private readonly IBattleShipService _battleShipService;
        private readonly IEncryptionService _encryptionService;

        public BattleShipController(IBattleShipService battleShipService
            , IEncryptionService encryptionService)
        {
            _battleShipService = battleShipService;
            _encryptionService = encryptionService;
        }

        [HttpGet("new")]
        public ActionResult<string> Get()
        {
            var vm = _battleShipService.NewGame();

            try
            {
                return _encryptionService.Encrypt(vm);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("game-status")]
        public ActionResult<GameStatusVM> GetGameStatus(GameStatusInputVM input)
        {
            if (input == null) return BadRequest($"Bad Request:{nameof(input)}");
            if (string.IsNullOrWhiteSpace(input.GameProgressCode)) return BadRequest($"Bad Request:{nameof(input.GameProgressCode)}");

            try
            {
                var gameProgressVM = _encryptionService.Decrypt<GameProgressVM>(input.GameProgressCode);
                return new GameStatusVM
                {
                    Hits = gameProgressVM.Hits,
                    Misses = gameProgressVM.Misses
                };
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("attack")]
        public ActionResult<AttackOutputVM> Attack(AttackInputVM input)
        {
            if (input == null) return BadRequest(nameof(input));
            if (string.IsNullOrWhiteSpace(input.CoOrd)) return BadRequest($"Bad Request:{nameof(input.CoOrd)}");
            if (string.IsNullOrWhiteSpace(input.GameProgressCode)) return BadRequest($"Bad Request:{nameof(input.GameProgressCode)}");

            try
            {
                var gameProgressVM = _encryptionService.Decrypt<GameProgressVM>(input.GameProgressCode);
                var updatedVM = _battleShipService.Attack(input.CoOrd, gameProgressVM);

                var updatedGameProgressCode = _encryptionService.Encrypt(updatedVM);
                return new AttackOutputVM
                {
                    GameProgressCode = updatedGameProgressCode,
                    Hits = updatedVM.Hits,
                    Misses = updatedVM.Misses
                };
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}