using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class Doctor
{
    public int Iddoctor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Horariodeatencion { get; set; }
}
