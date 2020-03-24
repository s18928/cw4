using cw3.DAL;
using cw3.Models;
using cw3.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
     

        [HttpGet]
        public IActionResult GetStudents([FromServices] IStudentDal _dbService)
        {
            var list = _dbService.GetStudents();

           
            return Ok(list);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudents([FromServices] IStudentDal _dbService, string indexNumber)
        {

            return Ok(_dbService.GetStudent(indexNumber));
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";

            return Ok(student);
        }

        //[HttpDelete("{id:int}")]
        //public IActionResult DeleteStudent(int id)
        //{
        //    return Ok($"Usuwanie ukonczone, student: {_dbService.GetStudent(id)} usuniety");
        //}

        //[HttpPut("{id:int}")]
        //public IActionResult PutStudent(int id)
        //{
        //    return Ok($"Aktualizacja ukonczona, student: {_dbService.GetStudent(id)} zaktualizowany");
        //}



        //[HttpPost("{id:int}")]
        //public string GetStudents([FromRoute] int id)
        //{
        //    return $"Chce informacje o studencie o ID: {id}";
        //}

        //[HttpPost]
        //public string GetStudents([FromBody]Student student)
        //{
        //    return "Kowal, Nowak";
        //}



    }
}