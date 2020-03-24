﻿using cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            //_students = new List<Student>
            //{
            //    new Student{IdStudent = 0, FirstName = "Jan", LastName = "Kowalski" },
            //    new Student{IdStudent = 1, FirstName = "Anna", LastName = "Nowak"},
            //    new Student{IdStudent = 2, FirstName = "Kasia", LastName = "Kowalczyk"}
            //};
        }


        public string GetStudent(int id)
        {
            return $"{_students.ElementAt(id).IndexNumber} {_students.ElementAt(id).FirstName} {_students.ElementAt(id).LastName}";
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}
