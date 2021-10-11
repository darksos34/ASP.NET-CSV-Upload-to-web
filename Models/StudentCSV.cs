using System.ComponentModel.DataAnnotations;
using MailBee.Mime;

namespace CVSUpload.Models
{
    public class StudentCSV
    {
        public int EmployeeId { get; set; }
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [StringLength(100)]
        public string Designation { get; set; }
        public int Salary { get; set; }
        public EmailAddress Email{ get; set; }
    }
}