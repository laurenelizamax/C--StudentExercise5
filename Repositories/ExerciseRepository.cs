using System.Collections.Generic;
using System.Data.SqlClient;


namespace StudentEx5.Data
{
    class ExerciseRepository
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
        public List<Exercise> GetAllExercises()
        {
        
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ExerciseLanguage FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> allExercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int exName = reader.GetOrdinal("ExerciseName");
                        string exNameValue = reader.GetString(exName);

                        int exLanguage = reader.GetOrdinal("ExerciseLanguage");
                        string exLangValue = reader.GetString(exLanguage);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            ExerciseName = exNameValue,
                            ExerciseLanguage = exLangValue

                        };

                        allExercises.Add(exercise);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return allExercises;
                }
            }
        }
        // Get exercise by language picked
        public List<Exercise> GetJavaScriptExercises(string language)
        {
          
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, ExerciseName, ExerciseLanguage FROM Exercise 
                                        WHERE ExerciseLanguage = @language";
                    cmd.Parameters.AddWithValue("@language", language);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> javaScriptExercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);
                        int exName = reader.GetOrdinal("ExerciseName");
                        string exNameValue = reader.GetString(exName);
                        int exLanguage = reader.GetOrdinal("ExerciseLanguage");
                        string exLangValue = reader.GetString(exLanguage);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            ExerciseName = exNameValue,
                            ExerciseLanguage = exLangValue

                        };

                        javaScriptExercises.Add(exercise);
                    }

                    reader.Close();

                    return javaScriptExercises;
                }
            }
        }
        // Add a new exercise
        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                  
                    cmd.CommandText = @"INSERT INTO Exercise (ExerciseName, ExerciseLanguage) 
                                       OUTPUT INSERTED.Id Values (@ExerciseName, @ExerciseLanguage)";
                    cmd.Parameters.Add(new SqlParameter("@ExerciseName", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@ExerciseLanguage", exercise.ExerciseLanguage));

                    int id = (int)cmd.ExecuteScalar();

                    exercise.Id = id;
                }
            }
        }
    }
}