using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Services;

namespace tmretApi.Controllers
{
    [Route("api/degafisetting")]
    [ApiController]
    public class DegafiSettingController : ControllerBase
    {



        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public DegafiSettingController(IUnitOfWork unitOfWork, JwtService jwtService)
        {


            _unitofwork = unitOfWork;
            _jwtService = jwtService;


        }
        [HttpGet]

        public List<DegafiSetting> GetAll(Guid userId)
        {


            return _unitofwork.degafiSettingRepository.GetAll(userId);
        }


        [HttpGet("GetTemplate")]

        public IdTemplate GetTemplateById(Guid mahberId)
        {

            return _unitofwork.degafiSettingRepository.getTemplateById(mahberId);
        }






            [HttpPost]


        public async Task<ActionResult> Post([FromBody] DegafiSetting desetting)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                desetting.ID = Guid.NewGuid();
                desetting.createdAt = DateTime.UtcNow;
                desetting.createdBy = userId;


                await _unitofwork.degafiSettingRepository.Create(desetting);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPost("IdTemplate")]


        public async Task<ActionResult> Post([FromForm] IdTemplate idTemplate)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                idTemplate.ID = Guid.NewGuid();
                idTemplate.createdAt = DateTime.UtcNow;
                idTemplate.createdBy = userId;


                
                


                await _unitofwork.degafiSettingRepository.Create(idTemplate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }









        [HttpPut]
        public async Task<ActionResult> Update([FromBody] DegafiSetting desetting)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                desetting.createdBy = userId;
                desetting.updatedAt = DateTime.UtcNow;


                await _unitofwork.degafiSettingRepository.Update(desetting);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();





        }




        [HttpPut("IdTemplate")]
        public async Task<ActionResult> Update([FromForm] IdTemplate idTemplate)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);


                idTemplate.createdBy = userId;
                idTemplate.updatedAt = DateTime.UtcNow;


                await _unitofwork.degafiSettingRepository.Update(idTemplate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();





        }


        [HttpDelete]

        public async Task<ActionResult> Delete(Guid desetingId)
        {

            try
            {
                await _unitofwork.degafiSettingRepository.Delete(desetingId);


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
