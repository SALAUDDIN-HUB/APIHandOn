using System;
using System.Collections.Generic;

namespace HandsOnPractice.Models
{
    public partial class Project4
    {
        public Project4()
        {
            Employee = new HashSet<Employee>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
