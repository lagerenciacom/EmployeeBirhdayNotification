using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpBirhyNotification.Web.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}