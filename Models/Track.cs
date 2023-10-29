using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HernandezJorge_Musica.Models;

public partial class Track
{
    public int TrackId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres")]
    [MinLength(2, ErrorMessage = "El campo no puede tener menos de 2 caracteres")]
    [DisplayName("Nombre")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(0, ErrorMessage = "El campo no puede tener menos de 0 caracteres")]
    public int? AlbumId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [DisplayName("TipoMediaId")]
    public int MediaTypeId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [DisplayName("GeneroId")]
    public int? GenreId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MaxLength(100, ErrorMessage = "El campo no puede tener más de 100 caracteres")]
    [MinLength(2, ErrorMessage = "El campo no puede tener menos de 2 caracteres")]
    [DisplayName("Compositor")]
    public string? Composer { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [MinLength(1, ErrorMessage = "El campo no puede tener menos de 1 caracter")]
    [DisplayName("Milisegundos")]
    public int Milliseconds { get; set; }

    public int? Bytes { get; set; }

    [DisplayName("Precio Unitario")]
    public decimal UnitPrice { get; set; }

    public virtual Album? Album { get; set; }
}
