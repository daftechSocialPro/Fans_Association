using Microsoft.AspNetCore.Mvc;
using tmretApi.Services;
using tmretApi.Dtos;
using tmretApi.Entities;
using tmretApi.Helpers;

using MlkPwgen;
using Microsoft.AspNetCore.SignalR;
using tmretApi.Hubs.EncoderHub;

namespace tmretApi.Controllers
{
    [Route("api/matches")]


    public class MatchController : Controller
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        private IHubContext<EncoderHub, IEncoderHubInterface> _matchHub;
        public MatchController(IUnitOfWork unitofwork , JwtService jwtService, IHubContext<EncoderHub, IEncoderHubInterface> matchHub)
        {

            _unitofwork = unitofwork;
            _jwtService = jwtService;
            _matchHub = matchHub;

        }
        [HttpGet("score")]

        public async Task<List<Matches>> GetMatches()
        {

            return await _unitofwork.matchRepository.GetMatches();
        }

        [HttpPut("ScoreUpdate")]

        public async Task<ActionResult> ScoreUpdate([FromForm] ScoreDto score)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);

                await _unitofwork.matchRepository.ScoreUpdate(score);

                
                var homeUpdate = new homeUpdate
                {
                    team = _unitofwork.teamRepository.GetAllTable(),  
                    matches = await _unitofwork.matchRepository.GetMatches(),
                    goalViews = _unitofwork.playerRepository.getGolasAndAssist()

                };
                await _matchHub.Clients.All.getTeams(homeUpdate);              

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();






           
        }

            [HttpGet("getbyWeek")]

        public ActionResult<List<Matches>> GetById(int gameWeek)
        {


            return _unitofwork.matchRepository.GetByWeek(gameWeek);

        }

        [HttpPost]

        public async Task<ActionResult> Register( [FromForm] Matches match)
        {

            

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);

               // match.MatchDate = ToStringUtc(match.MatchDate);
                match.createdBy = userId;
                match.ID = Guid.NewGuid();


                await _unitofwork.matchRepository.Create(match);
                await _matchHub.Clients.All.getMatch(await _unitofwork.matchRepository.GetMatches());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }




        [HttpGet]
        public ActionResult<List<Matches>> GetAll()
        {


            return _unitofwork.matchRepository.GetAll();

        }


        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Matches match)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                match.createdBy = userId;               


                await _unitofwork.matchRepository.Update(match);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();





        }

        [HttpDelete]

        public async Task<ActionResult> Delete(Guid matchId)
        {

            try
            {
                await _unitofwork.matchRepository.Delete(matchId);


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