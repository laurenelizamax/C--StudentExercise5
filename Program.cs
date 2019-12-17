using StudentEx5.Data;
using System;
using Microsoft.Data.SqlClient;
using StudentEx5.Models;
using StudentEx5.Repositories;

namespace StudentEx5
{
    class Program
    {
        static void Main(string[] args)
        {
            var exerciseRepo = new ExerciseRepository();

            //// Get All Exercise
            var allExercises = exerciseRepo.GetAllExercises();

            Console.WriteLine("All Exercises");
            Console.WriteLine("---------------");
            foreach (var ex in allExercises)
            {
                Console.WriteLine(ex.ExerciseName, ex.ExerciseLanguage);
            }
            Console.WriteLine("---------------");

            ////// Get Javascript Exercises
            //Console.WriteLine("What language do you want?");
            //var filterLang = Console.ReadLine();
            //var javaSExercises = exerciseRepo.GetJavaScriptExercises(filterLang);

            //foreach (var js in javaSExercises)
            //{
            //    Console.WriteLine($"{js.ExerciseName}, {js.ExerciseLanguage}");
            //}


            //Console.WriteLine("---------------");
            //// Add a new Exercise
            //var newExercise = new Exercise();
            //Console.WriteLine("What is the name of the exericse you would like to add?");
            //newExercise.ExerciseName = Console.ReadLine();
            //Console.WriteLine("What language is your exercise in?");
            //newExercise.ExerciseLanguage = Console.ReadLine();

            //exerciseRepo.AddExercise(newExercise);

            Console.WriteLine("---------------");

            var instructorRepo = new InstructorRepository();

            // Get all Instructors with Cohort Id
            var allInstructors = instructorRepo.GetAllInstructors();

            Console.WriteLine("All Instructors");
            foreach (var teach in allInstructors)
            {
                Console.WriteLine($"{teach.FirstName} {teach.LastName} {teach.CohortId}");
            }

            Console.WriteLine("---------------");


            // Add a new Instructor
            var newInstructor = new Instructor();
            Console.WriteLine("What is the Instructor's first name?");
            newInstructor.FirstName = Console.ReadLine();
            Console.WriteLine("What is the Instructor's last name?");
            newInstructor.LastName = Console.ReadLine();
            Console.WriteLine("What is the Instructor's slack?");
            newInstructor.SlackHandle = Console.ReadLine();
            Console.WriteLine("What is the Instructor's specialty?");
            newInstructor.Specialty = Console.ReadLine();
            Console.WriteLine("What cohort is the Instructor in?");
            //newInstructor.CohortId = Int32.Parse(Console.ReadLine());

            newInstructor.Cohort.Id = Convert.ToInt32(Console.ReadLine());

            instructorRepo.AddInstructor(newInstructor);


            Console.WriteLine("---------------");

            // Add an exercise to a student
            var studentRepo = new StudentRepository();
            Console.WriteLine("Choose Student By Id");
            var studentWithExercise = Convert.ToInt32(Console.ReadLine());

            foreach (var studentExercise in studentWithExercises.Exercise)
            {
                Console.WriteLine($"{studentWithExercises.FirstName}  is working on {studentExercise.ExerciseName}");
            }

            Console.ReadLine();





        }
    }
}
