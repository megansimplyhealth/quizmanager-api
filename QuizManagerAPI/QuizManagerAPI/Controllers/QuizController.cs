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
        //User Id=sa;Password=R(aZNQcsx49!u3
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
    }
}
