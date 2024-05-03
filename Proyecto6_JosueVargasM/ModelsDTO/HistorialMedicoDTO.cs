using Proyecto6_JosueVargasM.Models;

namespace Proyecto6_JosueVargasM.ModelsDTO
{
    public class HistorialMedicoDTO
    {

        public int Idhistorial { get; set; }

        public string? Paciente { get; set; }

        public string? Diagnostico { get; set; }

        public string? Examenes { get; set; }

        public int? Edad { get; set; }

        public string? Correo { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();


    }
}
