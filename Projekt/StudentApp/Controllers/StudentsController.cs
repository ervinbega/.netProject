using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Models;
using StudentApp.Data.VM;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {

            //NOTE: Merren te gjithe studentet nga databaza
            var allStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Student 1",
                    LastName = "Student 1",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Student 2",
                    LastName = "Student 2",
                    DateOfBirth = DateTime.Now.AddYears(-21),
                    GraduationYear = 2023,
                    IsActive = true,
                    DateCreated = DateTime.Now,
                    DateUpdated = null,
                }
            };
            return Ok(allStudents);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //NOTE: Merret vetem nje student nga databaza me id
            var student = new Student()
            {
                Id = 1,
                FirstName = "Alijandro",
                LastName = "Firanj",
                GraduationYear = 2023,
                IsActive = true,
                DateOfBirth = DateTime.Now.AddYears(-20),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentVM studentVM)
        {
            var student = new Student()
            {
                // ID generated from Database
                FirstName = studentVM.FirstName,
                LastName = studentVM.LastName,
                GraduationYear = studentVM.GraduationYear,
                DateOfBirth = studentVM.DateOfBirth,

                //From Database
                IsActive = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = null
            };

            //Save to Database
            return Created("", student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] StudentVM studentVM, int id)
        {
            //Get student by id fro mDatabase
            var studentToUpdate = new Student()
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                GraduationYear = 2023,
                IsActive = true,
                DateOfBirth = DateTime.Now.AddYears(-20)
            };

            //Update student data
            studentToUpdate.FirstName = studentVM.FirstName;
            studentToUpdate.LastName = studentVM.LastName;
            studentToUpdate.GraduationYear = studentVM.GraduationYear;
            studentToUpdate.IsActive = studentVM.IsActive;
            studentToUpdate.DateOfBirth = studentVM.DateOfBirth;
            studentToUpdate.DateUpdated = DateTime.UtcNow;

            //Updeta student on Database

            var response = new Response
            {
                Message = $"Student with id={id} was updated",
                Data = studentToUpdate
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            //NOTE: Kalohet Id si parameter dhe fshihet Student nga databaza

            return Ok($"Student with id {id} deleted");
        }



    }

}
