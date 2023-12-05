using System;
using System.Collections.Generic;

namespace CongresoApi.Models;

public partial class Conferencia
{
    public int IdConf { get; set; }

    public DateTime Horario { get; set; }

    public string NombreConf { get; set; } = null!;

    public string Conferencista { get; set; } = null!;

    public virtual ICollection<Asiste> Asistes { get; set; } = new List<Asiste>();
}
