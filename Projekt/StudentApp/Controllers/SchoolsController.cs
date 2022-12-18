using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Models;
using StudentApp.Data.VM;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            
            var allSchools = new List<School>()
            {
                new School()
                {
                    Id = 1,
                    Name = "School 1",
                    Address = "Address 1",
                    YearEstablished = 2000
                },
                new School()
                {
                    Id = 2,
                    Name = "School 2",
                    Address = "Address 2",
                    YearEstablished = 2001
                }
            };

            return Ok(allSchools);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            var school = new School()
            {
                Id = 1,
                Name = "School 1",
                Address = "Address 1",
                YearEstablished = 2000
            };

            return Ok(school);
        }


        [HttpPost]
        public IActionResult AddSchool([FromBody] SchoolVM schoolVM)
        {
            
            var school = new School()
            {
                
                Name = schoolVM.Name,
                Address = schoolVM.Address,
                YearEstablished = schoolVM.YearEstablished,

                
                DateCreated = DateTime.UtcNow,
                DateUpdated = null
            };

            
            return Created("", school);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchool([FromBody]SchoolVM schoolVM, int id)
        {
            
            var school = new School()
            {
                Id = 1,
                Name = "Univesiteti Beder",
                Address = "Address 1",
                YearEstablished = 2000
            };


            
            school.Name = schoolVM.Name;
            school.Address = schoolVM.Address;
            school.YearEstablished = schoolVM.YearEstablished;
            school.DateUpdated = DateTime.UtcNow;

            

            return Ok($"School with id = {id} was updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            

            return Ok($"School with id {id} deleted");
        }


    }
}
