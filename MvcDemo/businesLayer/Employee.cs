using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace businesLayer
{
    public class Employee
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
