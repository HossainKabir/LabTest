using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Entity
{
    public class UserTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AppUserId { get; set; }
        public AppUser Users { get; set; }
    }
}
