using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/season")]
    [ApiController]
    public class SeasonController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public SeasonController(IUnitOfWork unitofwork, JwtService jwtService)
        {

            _unitofwork = unitofwork;
            _jwtService = jwtService;

        }

        [HttpPost]

        public async Task<ActionResult> Register([FromBody] Season season)
        {


            try
            {
                var jwt = Request.Cookies["jwt"];
            var token = _jwtService.verify(jwt);
            Guid userId = Guid.Parse(token.Issuer);


            season.createdBy = userId;
            season.createdAt = DateTime.UtcNow;

            await _unitofwork.seasonRepository.Create(season);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();

        }

        [HttpGet]
        public ActionResult<List<Season>> GetAll()
        {
            return _unitofwork.seasonRepository.GetAll();

        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Season season)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                season.createdBy = userId;
                season.updatedAt = DateTime.UtcNow;

                await _unitofwork.seasonRepository.Update(season);

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
