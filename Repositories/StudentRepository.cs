using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using StudentEx5.Models;


namespace StudentEx5.Repositories
{
    class StudentRepository

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

            // Add a new Exercise to a Student
        //    public void AddStudentExercise(StudentExercise student)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {

        //            cmd.CommandText = @"INSERT INTO StudentExercise (StudentId, ExerciseId) 
        //             Values (@Studentid, @ExerciseId)";
        //            cmd.Parameters.AddWithValue("@StudentId", StudentExercise.StudentId);
        //            cmd.Parameters.AddWithValue("@ExerciseId", StudentExercise.exerciseId);


        //                int id = (int)cmd.ExecuteScalar();

        //            student.Id = id;
        //        }
            //}
        }
    }
}