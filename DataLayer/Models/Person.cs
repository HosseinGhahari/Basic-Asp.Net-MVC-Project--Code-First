using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Person
    {
        // we create our table in this section
        // every property complete the table we want
        // we also specify the Requirements of the table

        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Family { get; set; }

        [Required]
        [MaxLength(100)]
        public string Webstie { get; set; }

    }
}
