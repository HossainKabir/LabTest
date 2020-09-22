using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domain.Models.DTOs
{
    public class VMDepartment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [DisplayName("Department")]
        public string  Name { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        
        public int CourseAssignId { get; set; }
        public string AssignedTeacherName { get; set; } 
        public List<VMDepartment> Departments { get; set; }
        public List<VMDepartment> CourseStat { get; set; }

    }
}