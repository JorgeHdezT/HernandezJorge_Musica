using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HernandezJorge_Musica.Models;

public partial class Album
{
    public int AlbumId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres")]
    [MinLength(3, ErrorMessage = "El campo no puede tener menos de 3 caracter")]
    [DisplayName("Titulo")]
    public string Title { get; set; } = null!;

    [DisplayName("ArtistaId")]
    public int ArtistId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MaxLength(20, ErrorMessage = "El campo no puede tener más de 20 caracteres")]
    [MinLength(2, ErrorMessage = "El campo no puede tener menos de 2 caracter")]
    [DisplayName("Artista")]
    public virtual Artist Artist { get; set; } = null!;

    [DisplayName("Canciones")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
