using System;
using System.Collections.Generic;

namespace CongresoApi.Models;

public partial class Asiste
{
    public int IdParticipanteConf { get; set; }

    public int FkParticipantes { get; set; }

    public int FkConferencias { get; set; }

    public virtual Conferencia? FkConferenciasNavigation { get; set; } = null!;

    public virtual Participante? FkParticipantesNavigation { get; set; } = null!;
}
