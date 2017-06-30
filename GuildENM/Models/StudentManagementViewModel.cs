using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildENM.Models
{
    public class StudentManagementViewModel
    {
        public List<StudentUser> UnAssignedStudents { get; set; }
        public List<StudentUser> MyStudents { get; set; }

        public StudentManagementViewModel()
        {
            UnAssignedStudents = new List<StudentUser>();
            MyStudents = new List<StudentUser>();
        }
        
    }
}