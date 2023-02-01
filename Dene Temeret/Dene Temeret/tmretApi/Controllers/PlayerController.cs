using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;

using tmretApi.Services;
using static tmretApi.Services.Player.PlayerRepository;

namespace tmretApi.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public PlayerController(IUnitOfWork unitOfWork, JwtService jwtService)
        {


            _unitofwork = unitOfWork;
            _jwtService = jwtService;


        }

        [HttpGet("getplayerName")]

        public string getPlayerName(Guid playerId)
        {


            return _unitofwork.playerRepository.getPlayerName(playerId);
        }
        [HttpGet]

        public List<Player> getbyId ( Guid teamID)
        {

            return _unitofwork.playerRepository.GetById(teamID);
        }

        [HttpGet("getStat")]

        public List<GoalView> GetStat()
        {

            return _unitofwork.playerRepository.getGolasAndAssist();
        }




        [HttpPost]


        public async Task<ActionResult> Post([FromForm] Player player)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                player.ID = Guid.NewGuid();
                player.createdAt = DateTime.UtcNow;
                player.createdBy = userId;


                await _unitofwork.playerRepository.Create(player);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Player player)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                player.createdBy = userId;


                await _unitofwork.playerRepository.Update(player);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();





        }
    }
}
