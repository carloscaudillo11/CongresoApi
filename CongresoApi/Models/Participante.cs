using System;
using System.Collections.Generic;

namespace CongresoApi.Models;

public partial class Participante
{
    public int IdParticipantes { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Twitter { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public string Ocupacion { get; set; } = null!;

    public virtual ICollection<Asiste> Asistes { get; set; } = new List<Asiste>();
}
