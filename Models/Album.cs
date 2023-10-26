using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace HernandezJorge_Musica.Models;

public partial class Album
{
    
    public int AlbumId { get; set; }

    [DisplayName("Titulo")]
    public string Title { get; set; } = null!;

    [DisplayName("ArtistaId")]
    public int ArtistId { get; set; }

    [DisplayName("Artista")]
    public virtual Artist Artist { get; set; } = null!;

    [DisplayName("Canciones")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
