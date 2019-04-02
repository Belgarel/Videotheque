using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    class Media
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int MediaId { get; set; }
        [Required]
        public Boolean Seen { get; set; }
        public int Rated { get; set; }
        [Required]
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Synopsis { get; set; }
        public string ImagePath { get; set; }
        public string DateReleae { get; set; }
        public int Duration { get; set; }
        public int MinAge { get; set; }
        [Required]
        public TypeMedia Type { get; set; }
        public Language LanguageVO { get; set; }
        [Required]
        public Language LanguageMedia { get; set; }
        public Language LanguageSubtitles { get; set; }
        public Boolean PhysicalSupport { get; set; }
        public Boolean NumericalSupport { get; set; }

        [InverseProperty(nameof(GenreMedia.Media))]
        public List<GenreMedia> GenreMedias { get; set; }
        [InverseProperty(nameof(Episode.Media))]
        public List<Episode> Episodes { get; set; }

    }
}
