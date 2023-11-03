using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HernandezJorge_Musica.Models
{
    public class Review
    {
        [DisplayName("ReviewId")]
        public int ReviewId { get; set; }

        [ForeignKey("ArtistId")]
        [DisplayName("ArtistaId")]
        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres")]
        [MinLength(2, ErrorMessage = "El campo no puede tener menos de 3 caracter")]
        [DisplayName("Titulo")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength(500, ErrorMessage = "El campo no puede tener más de 5100 caracteres")]
        [MinLength(0, ErrorMessage = "El campo no puede tener menos de 0 caracter")]
        [DisplayName("Comentario")]
        public string Comentario { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [MaxLength(3, ErrorMessage = "El campo no puede tener más de 3 caracteres")]
        [MinLength(0, ErrorMessage = "El campo no puede tener menos de 0 caracter")]
        [DisplayName("Puntuacion")]
        public float Rating { get; set; }

    }
}
