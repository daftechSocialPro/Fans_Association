using Microsoft.AspNetCore.Mvc;
using tmretApi.Services;
using tmretApi.Dtos;
using tmretApi.Entities;
using tmretApi.Helpers;

using MlkPwgen;

namespace tmretApi.Controllers
{
    [Route("api/mahber")]


    public class MahberController : Controller
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly IMailService _mailService;
        private readonly JwtService _jwtService;

        public MahberController(IUnitOfWork unitofwork, IMailService mailService, JwtService jwtService)
        {

            _unitofwork = unitofwork;
            _mailService = mailService;
            _jwtService = jwtService;

        }

        [HttpGet("getbyid")]

        public ActionResult<DegafiMahber> GetById(Guid mahberId)
        {


            return _unitofwork.mahberRepository.GetById(mahberId);

        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] MahberDto mahber)
        {

            string password = PasswordGenerator.Generate();
            MailRequest request = new MailRequest
            {
                ToEmail = mahber.email,
                Subject = "Credential",
                Body = "<h1>dear :</h1> " + mahber.name + "you can log in 'https://localhost:4000' using <h1>username</h1>" + mahber.email + " <h1>Password :</h1> " + password

            };
            try
            {
                await _mailService.SendEmailAsync(request);

                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.verify(jwt);


                Guid userId = Guid.Parse(token.Issuer);

                var user = new User
                {

                    ID = Guid.NewGuid(),
                    fullName = mahber.name,
                    email = mahber.email,
                    password = BCrypt.Net.BCrypt.HashPassword(password),
                    userRole = UserRole.Mahber,
                    isActive = true,
                    createdAt = DateTime.UtcNow,
                    createdBy = userId

                };



                return Created("Success", _unitofwork.userRepository.Create(user));

            }
            catch
            {
                throw;
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] DegafiMahber mahber)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);
                var user = _unitofwork.userRepository.GetById(userId);

                mahber.ID = Guid.NewGuid();

                mahber.createdAt = DateTime.UtcNow;


                mahber.UserId = userId;
                mahber.createdBy = userId;




                await _unitofwork.mahberRepository.CreateMahber(mahber);
                await _unitofwork.SaveChanges();
            }
            catch
            {


                return Unauthorized();
            }

            return NoContent();



        }


        [HttpGet]
        public ActionResult<List<DegafiMahber>> GetAll()
        {




            return _unitofwork.mahberRepository.GetAll();

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] DegafiMahber mahber)
        {


            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);
                mahber.createdBy = userId;
                await _unitofwork.mahberRepository.Update(mahber);

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