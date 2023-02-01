using Microsoft.AspNetCore.Mvc;
using tmretApi.Services;
using tmretApi.Entities;
using tmretApi.Data;
using tmretApi.Helpers;
using Microsoft.EntityFrameworkCore;
using tmretApi.Hubs.EncoderHub;
using Microsoft.AspNetCore.SignalR;

namespace tmretApi.Controllers

{
    [Route("api/news")]
    public class NewsController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        private readonly IUnitOfWork _unitofwork;
        private readonly JwtService _jwtService;

        private IHubContext<EncoderHub,IEncoderHubInterface> _newsHub ;

        public NewsController(ApplicationDbContext context, IUnitOfWork unitofwork, JwtService jwtService,IHubContext<EncoderHub,IEncoderHubInterface> newsHub)
        {
            this.context = context;
            _unitofwork = unitofwork;
            _jwtService = jwtService;
            _newsHub = newsHub;
        }
        [HttpGet]
        public async Task<ActionResult<List<News>>> Get()
        {

            return await _unitofwork.newsRepository.getAll(NewsType.News);

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
                news.NewsType =NewsType.News;


                news.createdBy = userId;
                news.userId = userId;




                await _unitofwork.newsRepository.Create(news);
                await _unitofwork.SaveChanges();

                await _newsHub.Clients.All.getNews(await _unitofwork.newsRepository.getAll(NewsType.News));
                

            }
            catch
            {


                return Unauthorized();
            }

            return NoContent();



        }

        [HttpPut]

        public async Task<ActionResult> Update([FromForm] News news)
        {


            try
            {

                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.verify(jwt);
                Guid userId = Guid.Parse(token.Issuer);
                
                await _unitofwork.newsRepository.Update(news);
                await _newsHub.Clients.All.getNews(await _unitofwork.newsRepository.getAll(NewsType.News));


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