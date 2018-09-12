using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpBirhyNotification.Web.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}