using System;
using System.Collections.Generic;

namespace Proyecto6_JosueVargasM.Models;

public partial class UsuarioRol
{
    public int UsuarioRolId { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Recepcionistum> Recepcionista { get; set; } = new List<Recepcionistum>();
}
