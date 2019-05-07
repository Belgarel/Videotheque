using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    public class Episode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EpisodeId { get; set; }
        [Required]
        public int NumSeason { get; set; }
        [Required]
        public int NumEpisode { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime BroadcastDate { get; set; }

        public int MediaId { get; set; }
        [ForeignKey(nameof(MediaId))]
        public Media Media { get; set; }
    }
}
