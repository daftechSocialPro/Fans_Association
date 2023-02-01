using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public TeamController(IUnitOfWork unitofwork, JwtService jwtService)
        {

            _unitofwork = unitofwork;
            _jwtService = jwtService;

        }

        [HttpPost]

        public async Task<ActionResult> Register([FromForm] Team team)
        {


            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                team.createdBy = userId;
                team.createdAt = DateTime.UtcNow;

                await _unitofwork.teamRepository.Create(team);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();

        }

        [HttpGet]
        public ActionResult<List<Team>> GetAll()
        {
            return _unitofwork.teamRepository.GetAll();

        }

        [HttpGet("getAllTable")]
        public ActionResult<List<TeamView>> GetAllTable()
        {
            return _unitofwork.teamRepository.GetAllTable();

        }
        [HttpGet("getBySeasonId")]

        public ActionResult<List<Team>> GetBySeasonId(Guid seasonId)
        {
            return _unitofwork.teamRepository.GetBySeason(seasonId);

        }


        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Team team)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                team.createdBy = userId;
                team.updatedAt = DateTime.UtcNow;

                await _unitofwork.teamRepository.Update(team);

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
