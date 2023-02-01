using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Hubs.EncoderHub;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/matcheweeks/")]

    public class MatchWeekController : Controller
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        private IHubContext<EncoderHub, IEncoderHubInterface> _matchHub;
        public MatchWeekController(IUnitOfWork unitOfWork, JwtService jwtService, IHubContext<EncoderHub, IEncoderHubInterface> matchHub)
        {

            _unitofwork = unitOfWork;
            _jwtService = jwtService;
            _matchHub = matchHub;

        }
        [HttpGet]

        public List<MatchWeek> GetAll()
        {


            return _unitofwork.matchWeekRepository.GetAll();
        }



     
        [HttpPost]


        public async Task<ActionResult> Post([FromBody] MatchWeek matchWeek)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                matchWeek.ID = Guid.NewGuid();
                matchWeek.createdAt = DateTime.UtcNow;
                matchWeek.createdBy = userId;

                try
                {
                    await _unitofwork.matchWeekRepository.Create(matchWeek);

                }
                catch (Exception e)
                {

                    return Ok(e.Message);

                }


                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }



        [HttpPut]
        public async Task<ActionResult> Update([FromBody] MatchWeek matchWeek)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);

                matchWeek.updatedAt = DateTime.UtcNow;


                await _unitofwork.matchWeekRepository.Update(matchWeek);
           
                await _matchHub.Clients.All.getMatch(await _unitofwork.matchRepository.GetMatches());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();





        }



        [HttpDelete]
        public async Task<ActionResult> Delete(Guid advertId)
        {

            try
            {
                await _unitofwork.advertRepository.Delete(advertId);


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
