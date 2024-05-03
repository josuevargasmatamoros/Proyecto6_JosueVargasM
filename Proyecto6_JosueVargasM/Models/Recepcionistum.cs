using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class Recepcionistum
{
    public int Idrecepcionista { get; set; }

    public string? Nombre { get; set; }

    public string? Contrasennia { get; set; }

    public string? Apellidos { get; set; }

    public string? Cedula { get; set; }

    public int? UsuarioRolId { get; set; }

    public bool? Activo { get; set; }

    public virtual UsuarioRol? UsuarioRol { get; set; }
}
