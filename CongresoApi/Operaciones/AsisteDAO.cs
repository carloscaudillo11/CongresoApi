using CongresoApi.Context;
using CongresoApi.Models;

namespace CongresoApi.Operaciones
{
    public class AsisteDAO
    {
        //Creamos un objeto de contexto de DB
        public CongresoContext contexto = new CongresoContext();
        //Método para insertar un nuevo alumno a la BD.
        public bool insertar(int fkParticipantes, int fkConferencias)
        {
            try
            {

                Asiste asiste = new Asiste();
                asiste.FkParticipantes = fkParticipantes;
                asiste.FkConferencias = fkConferencias;

                contexto.Asistes.Add(asiste);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
