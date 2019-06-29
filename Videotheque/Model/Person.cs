using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Videotheque.Model
{
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        public PersonTitle Title { get; set; }
        [Required]
        public TypePerson Type { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string Nationality { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Picture { get; set; }

        [InverseProperty(nameof(PersonMedia.Person))]
        public List<PersonMedia> PersonMedias { get; set; }
    }
}