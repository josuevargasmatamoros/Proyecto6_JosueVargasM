using Proyecto6_JosueVargasM.Models;

namespace Proyecto6_JosueVargasM.ModelsDTO
{
    public class RecepcionistaPostDTO
    {
        public int Idrecepcionista { get; set; }

        public string? Nombre { get; set; }

        public string? Contrasennia { get; set; }

        public string? Apellidos { get; set; }

        public string? Cedula { get; set; }

        public int? UsuarioRolId { get; set; }

        public virtual UsuarioRol? UsuarioRol { get; set; }

    }
}
