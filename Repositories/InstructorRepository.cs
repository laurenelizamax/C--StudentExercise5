using System.Collections.Generic;
using System.Data.SqlClient;
using StudentEx5.Models;


namespace StudentEx5.Data
{
    class InstructorRepository
    {
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }


        ///  Returns a list of all exercises
        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, FirstName, LastName, CohortId
                                        FROM Instructor";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> allInstructors = new List<Instructor>();

                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        allInstructors.Add(instructor);
                    }

                    reader.Close();

                    return allInstructors;
                }
            }
        }

        // Add a new Instructor
        public void AddInstructor(Instructor instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) 
                                       OUTPUT INSERTED.Id Values (@FirstName, @LastName, @SlackHandle, @Specialty, @CohortId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@SlackHandle", instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@Specialty", instructor.Specialty));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", instructor.Cohort.Id));


                    int id = (int)cmd.ExecuteScalar();

                    instructor.Id = id;
                }
            }
        }
    }
}