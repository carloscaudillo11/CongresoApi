namespace Congreso.Models
{
    public class ParticipanteCongreso
    {
        public int fk_conf { get; set; }
        public DateTime HorarioConf { get; set; }
        public string NombreConf { get; set; } = null!;
        public string NombreParticipante { get; set; } = null!;

        public string ApellidoParticipante { get; set; } = null!;

        public string AvatarParticipante { get; set; } = null!;

        public string OcupacionParticipante { get; set; } = null!;

        public string TwitterParticipante { get; set; } = null!;

    }
}
