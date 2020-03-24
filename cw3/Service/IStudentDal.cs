using cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.Service
{
    public interface IStudentDal
    {
        public IEnumerable<Student> GetStudents();

        public string GetStudent(string index);
    }
}
