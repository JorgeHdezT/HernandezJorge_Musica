using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HernandezJorge_Musica.Models;

public partial class Album
{
    public int AlbumId { get; set; }

    [DisplayName("Título")]
    public string Title { get; set; } = null!;

    [DisplayName("ArtistaId")]
    public int ArtistId { get; set; }

    [DisplayName("Artista")]
    public virtual Artist Artist { get; set; } = null!;
}
