using WebAppOperacionesTDS.Models;

namespace WebAppOperacionesTDS.Data.Interface
{
    public interface IDAOperacion
    {
        public IEnumerable<Operacion> GetOperacion();
        int InsertOperaciones(Operacion operacion);
        Operacion GetIdOperacion(int id);
        Boolean UpdateOperacion(Operacion operacion);
        Boolean DeleteTrabajos(int id);
    }
}
