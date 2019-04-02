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
    class Genre
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }

        public string Libelle { get; set; }

        [InverseProperty(nameof(GenreMedia.Genre))]
        public List<GenreMedia> GenreMedias { get; set; }
    }
}
