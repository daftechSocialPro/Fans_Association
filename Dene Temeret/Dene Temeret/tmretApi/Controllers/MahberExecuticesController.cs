using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Services;

namespace MahberApi.Controllers
{
    [Route("api/mahberexec")]
    [ApiController]
    public class MahberExecuticesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public MahberExecuticesController(IUnitOfWork unitOfWork, JwtService jwtService)
        {


            _unitofwork = unitOfWork;
            _jwtService = jwtService;


        }
        [HttpGet]

        public async Task<List<MahberExecutives>> GetAll(Guid mahberId)
        {


            return await _unitofwork.mahberExecutiveRepostiory.GetAll(mahberId);
        }


        [HttpPost]


        public async Task<ActionResult> Post([FromForm] MahberExecutives executives)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                executives.ID = Guid.NewGuid();
                executives.createdAt = DateTime.UtcNow;
                executives.createdBy = userId;


                await _unitofwork.mahberExecutiveRepostiory.Create(executives);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] MahberExecutives executives)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                executives.createdBy = userId;


                await _unitofwork.mahberExecutiveRepostiory.Update(executives);
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
