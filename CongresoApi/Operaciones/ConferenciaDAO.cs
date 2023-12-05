using Congreso.Models;
using CongresoApi.Context;
using CongresoApi.Models;
using System.Linq;

namespace CongresoApi.Operaciones
{
    public class ConferenciaDAO
    {
        //Creamos un objeto de contexto de DB
        public CongresoContext contexto = new CongresoContext();

        //Método para seleccionar todas las conferencias
        public List<Conferencia> seleccionarTodos()
        {
            var conferencias = contexto.Conferencias.ToList<Conferencia>();
            return conferencias;
        }
        //metodo para aladir una conferencia
        public bool insertar(DateTime horario, string nombreconferencia, string conferencista)
        {
            try
            {
                Conferencia conferencia = new Conferencia();
                conferencia.Horario = horario;
                conferencia.NombreConf = nombreconferencia;
                conferencia.Conferencista = conferencista;

                contexto.Conferencias.Add(conferencia);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //recuperar conferencia por id
        public Conferencia seleccionar(int id)
        {
            var conferencia = contexto.Conferencias.Where(a => a.IdConf == id).FirstOrDefault();
            return conferencia;
        }
        //ediatr una conferencia
        public bool editar(int idconferencia, DateTime horario, string nombreconferencia, string conferencista)
        {
            try
            {
                var conferencia = seleccionar(idconferencia);
                if (idconferencia == null)
                {
                    return false;
                }
                else
                {
                    conferencia.IdConf = idconferencia;
                    conferencia.Horario = horario;
                    conferencia.NombreConf = nombreconferencia;
                    conferencia.Conferencista = conferencista;

                    contexto.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Participante y conferencia
        public List<ParticipanteCongreso> ParticipantesCongreso(int idConferencia)
        {
            var query = from conferencia in contexto.Conferencias
                        join asiste in contexto.Asistes on conferencia.IdConf equals asiste.FkConferencias
                        join participante in contexto.Participantes on asiste.FkParticipantes equals participante.IdParticipantes
                        where conferencia.IdConf == idConferencia
                        select new ParticipanteCongreso
                        {
                            fk_conf = conferencia.IdConf,
                            HorarioConf = conferencia.Horario,
                            NombreConf = conferencia.NombreConf,
                            NombreParticipante = participante.Nombre,
                            ApellidoParticipante = participante.Apellidos,
                            AvatarParticipante = participante.Avatar,
                            OcupacionParticipante = participante.Ocupacion,
                            TwitterParticipante = participante.Twitter
                        };
            return query.ToList();
        }
    }

}
