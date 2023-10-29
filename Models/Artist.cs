using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HernandezJorge_Musica.Models;

public partial class Artist
{
    [DisplayName("ArtistaId")]
    public int ArtistId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres")]
    [MinLength(2, ErrorMessage = "El campo no puede tener menos de 3 caracter")]
    [DisplayName("Nombre")]
    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
