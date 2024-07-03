using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using QuizManagerAPI.Models;
using Dapper;
using Microsoft.AspNetCore.Hosting.Server;
using static System.Net.Mime.MediaTypeNames;

namespace QuizManagerAPI.Controllers
{
    [Route("/quizmanagerservice/v1/")]
    //[ApiVersion("")]
    [ApiController]
    public class QuizController : Controller
    {
        [HttpGet]
        [Route("/Questions")]
        public ActionResult getQuestions()
        {
            var con = "Server=localhost;Database=QuizManager;User Id=quizuser;Password=password123;TrustServerCertificate=True;";
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
            var con = "Server=localhost;Database=QuizManager;User Id=quizuser;Password=password123;TrustServerCertificate=True;";

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

    }
    }
}
