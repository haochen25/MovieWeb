using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(256)]
        public string? Title { get; set; }
        public string? Overview { get; set; }
        [MaxLength(512)]
        public string? Tagline { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Budget { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Revenue { get; set; }
        [MaxLength(2084)]
        public string? ImdbUrl { get; set; }
        [MaxLength(2084)]
        public string? TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string? PosterUrl { get; set; }
        [MaxLength(2084)]

        public string? BackdropUrl { get; set; }
        [MaxLength(64)]
        public string? OriginalLanguage { get; set; }
        [MaxLength(7)]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Price { get; set; }
        [MaxLength(7)]
        public DateTime? CreatedDate { get; set; }
        [MaxLength(7)]
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

        public ICollection<MovieGenre>? GenresOfMovie { get; set; }
        public ICollection<Trailer>? Trailers { get; set; }
        public ICollection<MovieCrew>? CrewsOfMovie { get; set; }
        public ICollection<MovieCast>? CastsOfMovie { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Favorites>? UsersFavorited { get; set; }
        public ICollection<Purchase>? Purchasers { get; set; }

    }
}
