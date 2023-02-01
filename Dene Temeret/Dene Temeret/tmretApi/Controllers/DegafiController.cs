using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using tmretApi.Dtos;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Migrations;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/degafi")]
    [ApiController]
    public class DegafiController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public DegafiController(IUnitOfWork unitOfWork, JwtService jwtService)
        {


            _unitofwork = unitOfWork;
            _jwtService = jwtService;


        }
        [HttpGet]

        public async Task<ActionResult<List<Degafi>>> GetAll(Guid mahberId)
        {


            return Ok(await _unitofwork.degafiRepostiory.GetAll(mahberId));
        }
        [HttpGet("getPayment")]

        public async Task<List<Payment>> GetAllPayment(Guid fanId)
        {

            return await _unitofwork.degafiRepostiory.GetAllPaymentsByid(fanId);


        }




        [HttpPost("fromExcel")]
        

        public async Task <ActionResult> Post ([FromForm] FansFromExcel fansFromExcel)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                //degafi.ID = Guid.NewGuid();
                //degafi.createdAt = DateTime.UtcNow;
                //degafi.createdBy = userId;


                await _unitofwork.degafiRepostiory.CreateFromExcel(fansFromExcel);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }
        [HttpPost]


        public async Task<ActionResult> Post([FromForm] Degafi degafi)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                degafi.ID = Guid.NewGuid();
                degafi.createdAt = DateTime.UtcNow;
                degafi.createdBy = userId;


                await _unitofwork.degafiRepostiory.Create(degafi);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPost("regiserPayment")]


        public async Task<ActionResult> PostPayment([FromForm] Payment payment)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                payment.ID = Guid.NewGuid();
                payment.createdAt = DateTime.UtcNow;
                payment.createdBy = userId;


                await _unitofwork.degafiRepostiory.CreatePayment(payment);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }
        [HttpGet("getDate")]
        public string getDate()
        {

            return _unitofwork.degafiRepostiory.getDate();
        }

        [HttpGet("getPenality")]

        public double getPenality(string startDate, Guid degafiId)
        {
            return _unitofwork.degafiRepostiory.getPenality(startDate, degafiId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Degafi degafi)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                degafi.createdBy = userId;


                await _unitofwork.degafiRepostiory.Update(degafi);

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
