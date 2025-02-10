using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_34_4
{

    public class Person
    {
        [Key]
        [Column("Person_Id")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}

