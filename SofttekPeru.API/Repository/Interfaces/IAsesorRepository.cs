using SofttekPeru.Model;

namespace SofttekPeru.API.Repository.Interfaces
{
    public interface IAsesorRepository
    {
        public Asesor AccesoAsesor(int CodigoAsesor, string Password);
        public List<Asesor> getAsesores();
    }
}
