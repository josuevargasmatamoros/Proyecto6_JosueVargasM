using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class Cita
{
    public int Idcitas { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Paciente { get; set; }

    public string? Doctor { get; set; }

    public string? Estado { get; set; }

    public string? Motivo { get; set; }
}
