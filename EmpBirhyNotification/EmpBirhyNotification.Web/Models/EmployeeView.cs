using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmpBirhyNotification.Web.Models
{
    public class EmployeeView : Employee
    {
        [NotMapped]
        public HttpPostedFileBase PictureFile { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1}", Name, LastName); }
        }


    }
}