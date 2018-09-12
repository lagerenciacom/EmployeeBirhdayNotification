using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpBirhyNotification.Web.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [MaxLength(50,ErrorMessage ="You have exced Max Length for this field")]
        [Required(ErrorMessage ="This Field is Required")]
        public string Name { get; set; }

        [Display(Name="Last Name")]
        [StringLength(50,ErrorMessage ="The Field {0} acept Max length {1} an Min length {2} characters",MinimumLength =3)]
        public string LastName { get; set; }
                 
        public decimal? Salary { get; set; }

        public string Address { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? HireDate { get; set; }

        [Index("Employee_Email_Index",IsUnique =true)]
        [MaxLength(25, ErrorMessage = "You have exced Max Length for this field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int? Tel { get; set; }

        public int? Cel { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Image")]
        public string PictureRoute { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; } //fk

        [Display(Name = "Department")]
        public int DepartmentId { get; set; } //fk

        [Display(Name = "Status")]
        public int StatusId { get; set; } //fk

        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Department Department { get; set; }

    }
}