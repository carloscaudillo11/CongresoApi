using Congreso.Models;
using CongresoApi.Models;
using CongresoApi.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CongresoWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ConferenciasController : ControllerBase
    {
        private ConferenciaDAO conferenciaDAO = new ConferenciaDAO();
        /** 
          EndPoint para obtener todas las conferencias
             */
        [HttpGet("conferencias")]
        public ActionResult<List<Conferencia>> GetAsignaturas()
        {
            List<Conferencia> conferencias = conferenciaDAO.seleccionarTodos();

            if (conferencias == null ||conferencias.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron materias.
            }
            return conferencias;
        }
        /*Endpoint para recuperar conferencia por id
         */
        [HttpGet("Conferencia")]
        public Conferencia getConferencia(int id)
        {
            return conferenciaDAO.seleccionar(id);
        }
        /*Endpoint para Insertar una nueva conferencia
         */
        [HttpPost("conferencia")]
        public bool insertarConferencia([FromBody] Conferencia conferencia)
        {
            return conferenciaDAO.insertar(conferencia.Horario, conferencia.NombreConf, conferencia.Conferencista);
        }
        /*Endpoint para Listado de Asistentes a Conferencia
                 */
        [HttpGet("ConefrenciaParticipante")]
        public List<ParticipanteCongreso> getParticipanteCongresos(int idConferencia)
        {
            return conferenciaDAO.ParticipantesCongreso(idConferencia);
        }


    }
}
