using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    class GenreMedia
    {
        public int GenreId { get; set; }
        public int MediaId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }
        [ForeignKey(nameof(MediaId))]
        public Media Media { get; set; }
    }
}
