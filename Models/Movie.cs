using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [StringLength(25)]
        public string MovieName { get; set; }
        [Required]
        [StringLength(250)]
        public string MovieLink { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        virtual public Person Person { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        virtual public Genre Genre { get; set; }
    }
}
