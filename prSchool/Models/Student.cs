using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prSchool.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public int AccountNumber {  get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string email {  get; set; }
    }
}
