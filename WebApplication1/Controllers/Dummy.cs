//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebApplication1.Models.DTOs;
//using WebApplication1.Repositiory;

//namespace WebApplication1.Controllers
//{
//    [Route("api/v{version:apiVersion}/[controller]")]
//    [ApiController]
//    [ApiVersion("1.0")]
//    [ApiVersion("2.0")]
//    public class Dummy : ControllerBase
//    {
//        [HttpGet]
//        [MapToApiVersion("1.0")]
//        public ActionResult Get1()
//        {
//            List<char> alphabets = new List<char>();

//            for (char letter = 'A'; letter <= 'Z'; letter++)
//            {
//                alphabets.Add(letter);
//            }

//            // Return the list as a JSON response
//            return Ok(alphabets);
//        }
//        [HttpGet]
//        [MapToApiVersion("2.0")]
//        public ActionResult Get2()
//        {
//            List<char> alphabets = new List<char>();

//            for (char letter = 'a'; letter <= 'z'; letter++)
//            {
//                alphabets.Add(letter);
//            }

//            // Return the list as a JSON response
//            return Ok(alphabets);
//        }

        

//    }
//}
