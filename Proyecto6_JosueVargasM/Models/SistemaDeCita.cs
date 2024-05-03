using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class SistemaDeCita
{
    public int? Citas { get; set; }

    public int? Medico { get; set; }

    public int? Agendamedicos { get; set; }

    public virtual Doctor? AgendamedicosNavigation { get; set; }

    public virtual Cita? CitasNavigation { get; set; }

    public virtual Doctor? MedicoNavigation { get; set; }
}
