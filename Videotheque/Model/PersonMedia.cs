using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Videotheque.Model
{
    class PersonMedia
    {
        public int PersonMediaId { get; set; }

        public PersonMediaFunction Function { get; set; }

        public string Role { get; set; }

        public int MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public Media Media { get; set; }
    
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
