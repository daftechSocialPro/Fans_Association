using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/tmretexc")]
    [ApiController]
    public class TmretExecuticesController : ControllerBase
    {
         

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public TmretExecuticesController(IUnitOfWork unitOfWork, JwtService jwtService)
        {


            _unitofwork = unitOfWork;
            _jwtService = jwtService;


        }
        [HttpGet]

        public async Task<List<TmretExecutives>> GetAll()
        {


            return await _unitofwork.temretExecutiveRepostiory.GetAll();
        }


        [HttpPost]


        public async Task<ActionResult> Post([FromForm] TmretExecutives executives)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                executives.ID = Guid.NewGuid();
                executives.createdAt = DateTime.UtcNow;
                executives.createdBy = userId;


                await _unitofwork.temretExecutiveRepostiory.Create(executives);
                await _unitofwork.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm]TmretExecutives executives)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                executives.createdBy = userId;


               await _unitofwork.temretExecutiveRepostiory.Update(executives);
                //await _unitofwork.SaveChanges();
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

