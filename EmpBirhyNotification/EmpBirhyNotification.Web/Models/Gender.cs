using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpBirhyNotification.Web.Models
{
    public class Gender
    {
        public int GenderId { get; set; }

        [Display(Name = "Gender")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}