using System;
using System.Collections.Generic;
using System.Text;

namespace StudentEx5.Models
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }
        public int CohortId { get; set; }

        public List<Exercise> Exercise { get; set; }
        public Student()
        {
            Exercise = new List<Exercise>();
            }

    }
}
