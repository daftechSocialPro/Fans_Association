using Microsoft.AspNetCore.Mvc;
using tmretApi.Services;
using tmretApi.Entities;
using tmretApi.Data;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;



namespace tmretApi.Controllers

{
    [Route("api/videos")]
    public class VideoController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;
        public VideoController(ApplicationDbContext context, IUnitOfWork unitofwork, JwtService jwtService)
        {
            this.context = context;
            _unitofwork = unitofwork;
            _jwtService = jwtService;
        }
        [HttpGet]
        public async Task<ActionResult<List<News>>> Get()
        {

            return await _unitofwork.newsRepository.getAll(NewsType.Videos);

        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] News news)
        {

            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);
                var user = _unitofwork.userRepository.GetById(userId);

                news.ID = Guid.NewGuid();
                news.isApproved = false;
                news.isHeadLine = false;
                news.createdAt = DateTime.UtcNow;
                news.NewsType =NewsType.Videos;


                news.createdBy = userId;
                news.userId = userId;




                await _unitofwork.newsRepository.Create(news);
                await _unitofwork.SaveChanges();
            }
            catch
            {


                return Unauthorized();
            }

            return NoContent();



        }





    }
}