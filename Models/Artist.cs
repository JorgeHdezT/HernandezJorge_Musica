using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HernandezJorge_Musica.Models;

public partial class Artist
{
    [DisplayName("ArtistaId")]
    public int ArtistId { get; set; }

    [DisplayName("Nombre")]
    public string? Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
