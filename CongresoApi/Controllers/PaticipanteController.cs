using CongresoApi.Models;
using CongresoApi.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace CongresoWeb.Controllers
{
    [Route("api")]
    [ApiController]
    public class PaticipanteController : ControllerBase
    {
        private ParticipanteDAO participanteDAO = new ParticipanteDAO();

        /**
         *EndPoint para obtener un participante especifico
         */
        [HttpGet("participante")]
        public Participante getParticipante(int id)
        {
            return participanteDAO.seleccionar(id);
        }

        /** 
          EndPoint para obtener todos los participantes
             */
        [HttpGet("participantes")]
        public ActionResult<List<Participante>> GetParticipante()
        {
            List<Participante> participantes = participanteDAO.seleccionarTodos();

            if (participantes == null || participantes.Count == 0)
            {
                return null; // Puedes devolver un resultado null si la lista está vacía o no se encontraron materias.
            }
            return participantes;
        }


        /**
         *EndPoint para insertar un participante
         */
        [HttpPost("participante")]
        public bool insertarParticipante([FromBody] Participante participante)
        {
            return participanteDAO.insertar(participante.Nombre, 
                participante.Apellidos,participante.Email, participante.Twitter, participante.Avatar,participante.Ocupacion);
        }

        [HttpPut("Participante")]
        public bool editarParticipante([FromBody] Participante participante, int id)
        {
            return participanteDAO.editar(id, participante.Nombre,
                participante.Apellidos, participante.Email, participante.Twitter, participante.Avatar, participante.Ocupacion);
        }
    }
}
