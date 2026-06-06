using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCproject.Models
{
    public class Employee
    {
        public int empid { get; set; }
        public string empname { get; set; }
        public long mobilenumber { get; set; }
        public DateTime? doj { get; set; }
        public string empfunction { get; set; }
        public string personalemail { get; set; }
        public string emailaddress { get; set; }
        public string emppassword { get; set; }
        public string emptype { get; set; }
        public string StatusSignal { get; set; }
        public string empstatus { get; set; }
        public string empaddress { get; set; }
        public DateTime? lwd { get; set; }

    }
}