using CongresoApi.Context;
using CongresoApi.Models;

namespace CongresoApi.Operaciones
{
    public class ParticipanteDAO
    {
        //Creamos un objeto de contexto de DB
        public CongresoContext contexto = new CongresoContext();

        //Método para seleccionar todos los participantes
        public List<Participante> seleccionarTodos()
        {
            var participantes = contexto.Participantes.ToList<Participante>();
            return participantes;
        }

        //Método para seleccionar un alumno en especifico.
        public Participante seleccionar(int id)
        {
            var participante = contexto.Participantes.Where(a => a.IdParticipantes == id).FirstOrDefault();
            return participante;
        }

        //Método para insertar un nuevo alumno a la BD.
        public bool insertar(string nombre, string apellidos, string email, string twitter, string avatar, string ocupacion)
        {
            try
            {
                Participante participante = new Participante();
                participante.Nombre = nombre;
                participante.Apellidos = apellidos;
                participante.Email = email;
                participante.Twitter = twitter;
                participante.Avatar = avatar;
                participante.Ocupacion = ocupacion;

                contexto.Participantes.Add(participante);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Método para editar un participante.
        public bool editar(int id, string nombre, string apellidos, string email, string twitter, string avatar, string ocupacion)
        {
            try
            {
                var participante = seleccionar(id);
                if(participante == null)
                {
                    return false;
                }
                else
                {
                    participante.IdParticipantes = id;
                    participante.Nombre = nombre;
                    participante.Apellidos = apellidos;
                    participante.Email = email;
                    participante.Twitter = twitter;
                    participante.Avatar = avatar;
                    participante.Ocupacion = ocupacion;

                    contexto.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
