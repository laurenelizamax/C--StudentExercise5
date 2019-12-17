//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System.Data;
//using Microsoft.Data.SqlClient;
//using StudentEx5.Models;
//using Microsoft.AspNetCore.Http;
//using System;

//namespace StudentEx5
//{
//    class StudentController
//    {
//        [HttpGet]
//        public async Task<IActionResult> Get([FromQuery]int? cohortId, [FromQuery]string lastName)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"SELECT 
//                                        Id, 
//                                        FirstName, 
//                                        LastName, 
//                                        SlackHandle, 
//                                        CohortId 
//                                        FROM Student
//                                        WHERE 1=1";
//                    if (cohortId != null)
//                    {
//                        cmd.CommandText += " AND CohortId = @cohortId";
//                        cmd.Parameters.Add(new SqlParameter("@cohortId", cohortId));
//                    }
//                    if (lastName != null)
//                    {
//                        cmd.CommandText += " AND LastName LIKE @lastName";
//                        cmd.Parameters.Add(new SqlParameter("@lastName", "%" + lastName + "%"));
//                    }
//                    SqlDataReader reader = cmd.ExecuteReader();
//                    List<Student> allStudents = new List<Student>();
//                    while (reader.Read())
//                    {
//                        Student stu = new Student
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
//                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
//                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
//                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
//                        };
//                        allStudents.Add(stu);
//                    }
//                    reader.Close();
//                    return Ok(allStudents);
//                }
//            }
//        }
//    }
//}
