using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using QuizManagerAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Hosting.Server;
using static System.Net.Mime.MediaTypeNames;
using Azure;


namespace QuizManagerAPI.Controllers
{   
    [Route("/quizmanagerservice/v1/")]
    //[ApiVersion("")]
    [ApiController]
    public class QuizController : Controller
    {

        private readonly IConfiguration _configuration;

        public QuizController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("/Questions")]
        public ActionResult getQuestions()
        {
            var con = _configuration.GetConnectionString("quizConnectionString");
            List<Question> questions = new List<Question>();
            System.Console.WriteLine(con);
            using (IDbConnection db = new SqlConnection(con))
            //to do connection string - create sql user
            {
                
                questions = db.Query<Question>("Select * From Questions").ToList();
                //questionText = 
            }
            return Ok(questions);

        }

        [HttpPost]
        [Route("/Questions")]
        public ActionResult postQuestions(Question newQuestion)
        {
            var con = _configuration.GetConnectionString("quizConnectionString");

            if (newQuestion == null)
            {
                return BadRequest("Invalid question data.");
            }

            using (IDbConnection db = new SqlConnection(con))
            {
                var sqlQuery = "INSERT INTO Questions (QuestionText, AnswerOne, AnswerTwo, AnswerThree, AnswerFour, CorrectAnswer) VALUES (@QuestionText, @AnswerOne, @AnswerTwo, @AnswerThree, @AnswerFour, @CorrectAnswer)";
                var result = db.Execute(sqlQuery, new
                {
                    newQuestion.QuestionText,
                    newQuestion.AnswerOne,
                    newQuestion.AnswerTwo,
                    newQuestion.AnswerThree,
                    newQuestion.AnswerFour,
                    newQuestion.CorrectAnswer
                });
            }
            return Ok("Question added successfully." + newQuestion);
        }

        [HttpGet]
        [Route("/Responses")]
        public ActionResult getResponses()
        {
            var con = _configuration.GetConnectionString("quizConnectionString");
            List<Responses> responses = new List<Responses>();
            System.Console.WriteLine(con);
            using (IDbConnection db = new SqlConnection(con))
            //to do connection string - create sql user
            {

                responses = db.Query<Responses>("Select * From Responses").ToList();
                //questionText = 
            }
            return Ok(responses);

        }

        [HttpPost]
        [Route("/Responses")]
        public ActionResult postResponse(Responses newResponse)
        {
            var con = _configuration.GetConnectionString("quizConnectionString");

            if (newResponse == null)
            {
                return BadRequest("Invalid question data.");
            }

            using (IDbConnection db = new SqlConnection(con))
            {
                var sqlQuery = "INSERT INTO Responses (ResponseName, ResponseDate, ResponseTime, ResponseScore) VALUES (@ResponseName, @ResponseDate, @ResponseTime, @ResponseScore)";
                var result = db.Execute(sqlQuery, new
                {
                    newResponse.ResponseName,
                    newResponse.ResponseDate,
                    newResponse.ResponseTime,
                    newResponse.ResponseScore
                });
            }
            return Ok("Response added successfully." + newResponse);
        }

    }
}
