using CongresoApi.Models;
using CongresoApi.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CongresoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsisteController : ControllerBase
    {
        private AsisteDAO asisteDAO = new AsisteDAO();

        /**
         *EndPoint para insertar un participante
         */
        [HttpPost("Asiste")]
        public bool insertarUnr([FromBody] Asiste asiste)
        {
            return asisteDAO.insertar(asiste.FkParticipantes, asiste.FkConferencias);
        }
    }
}
 