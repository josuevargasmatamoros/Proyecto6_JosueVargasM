using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class HistorialMedico
{
    public int Idhistorial { get; set; }

    public string? Paciente { get; set; }

    public string? Diagnostico { get; set; }

    public string? Examenes { get; set; }

    public int? Edad { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
