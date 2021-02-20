using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentExercice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            " Lucas", " Aziz", " Theo", " Tony", " Martina", " Lea", " Astrid", " David"
        };

        private static readonly string[] Hobbies = new[]
        {
            " Like playing Soccer", " Enjoy music", " Hate Math", " love Physics", " Hate sport", " sleep in class", " is Australian", " Come from France"
        };

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Student
            {
                Summary = Hobbies[rng.Next(Hobbies.Length)],
                Class = rng.Next(-20, 55),
                Name = Names[rng.Next(Names.Length)]
            })
            .ToArray();
        }

        [HttpGet("list")]
        public IEnumerable<string> Get_List()
        {
            return Hobbies.ToList();
        }
    }
}
