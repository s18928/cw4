using cw3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.Service
{
    public class SqlServerDbDal : IStudentDal
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18928;Integrated Security=True";

        public IEnumerable<Student> GetStudents()
        {
            var list = new List<Student>();

            using (var con = new SqlConnection(ConString))
            using (var command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandText = "Select * from studentAPBD";

                con.Open();
                var dr = command.ExecuteReader();

                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                    st.IdEnrollment = dr["IdEnrollment"].ToString();

                    list.Add(st);
                }
            }
            return list;

        }

        public string GetStudent(string indexNumber)
        {
            var list = new List<string>();
            var str = "";

            using (var con = new SqlConnection(ConString))
            using (var command = new SqlCommand())
            {
                command.Connection = con;
                command.CommandText = "select StudentAPBD.FirstName, StudentAPBD.LastName, StudentAPBD.IndexNumber, StudiesAPBD.Name, EnrollmentAPBD.Semester  " +
                                    "from StudentAPBD INNER JOIN EnrollmentAPBD ON EnrollmentAPBD.IdEnrollment = StudentAPBD.IdEnrollment " +
                                    "INNER JOIN StudiesAPBD On StudiesAPBD.IdStudy = EnrollmentAPBD.IdStudy " +
                                    " WHERE StudentAPBD.IndexNumber = @index";

                command.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                var dr = command.ExecuteReader();


                while (dr.Read())
                {
                    str += dr["FirstName"].ToString() + " ";
                    str += dr["LastName"].ToString() + " ";
                    str += dr["IndexNumber"].ToString() + " ";
                    str += dr["Name"].ToString() + " ";
                    str += dr["Semester"].ToString() + " ";
                    list.Add(str);
                }
            }

            return str;
        }
    }
}
