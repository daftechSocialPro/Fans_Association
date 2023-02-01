using Microsoft.AspNetCore.Mvc;
using tmretApi.Services;
using tmretApi.Entities;
using tmretApi.Data;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;



namespace tmretApi.Controllers
{


    [Route("api/member")]
    public class MemberController :ControllerBase
    {


        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService ;
        public MemberController(IUnitOfWork unitOfWork,JwtService jwtService)
        {

            _unitofwork = unitOfWork;
            _jwtService = jwtService;

        }

       [HttpPost]
        public async Task<ActionResult> Post([FromForm] DegafiMahberExecutive member)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);
               

                member.ID = Guid.NewGuid();               
                member.createdAt = DateTime.UtcNow;
                member.createdBy = userId;
                member.isActive =true;

                await _unitofwork.memberRepository.Create(member);
                await _unitofwork.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return Unauthorized();
            }

            return NoContent();



        }


 [HttpGet]
        public async Task<ActionResult<List<DegafiMahberExecutive>>> Get(Guid mahberId)
        {

            return await _unitofwork.memberRepository.getAll(mahberId);

        }


    }
}