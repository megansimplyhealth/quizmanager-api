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
        //SHGRP-HTGTBY3
        {
            List<Question> questions = new List<Question>();
            using (IDbConnection db = new SqlConnection("Server=127.0.0.1;Database=QuizManager;User Id=sa;Password=R(aZNQcsx49!u3;Trusted_Connection=True;TrustServerCertificate=True"))
            //to do connection string - create sql user
            {

                questions = db.Query<Question>("Select * From Questions").ToList();
            }
            return Ok(questions);

        }
    }
}
