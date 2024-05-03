using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class Paciente
{
    public int Idpaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? Fechanacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Genero { get; set; }

    public int? FkHistorialmedico { get; set; }

    public virtual HistorialMedico? FkHistorialmedicoNavigation { get; set; }
}
