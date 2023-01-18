using SofttekPeru.API.Context;
using SofttekPeru.API.Repository.Interfaces;
using SofttekPeru.Model;

namespace SofttekPeru.API.Repository
{
    public class AsesorRepository : IAsesorRepository
    {
        public AsesorRepository()
        {
            using (var context = new ApiContext())
            {
                var asesores = new List<Asesor>
                {
                    new Asesor
                    {
                        CodigoAsesor = 72854591,
                        NombreAsesor = "Bryan Vislao Chavez",
                        PasswordAsesor = "1111"
                    },
                    new Asesor
                    {
                        CodigoAsesor = 728545955,
                        NombreAsesor = "Alexis Vislao Chavez",
                        PasswordAsesor = "2222"
                    },
                    new Asesor
                    {
                        CodigoAsesor = 72854522,
                        NombreAsesor = "Jose Luis Velazques",
                        PasswordAsesor = "3333"
                    }
                };

                context.Asesores.AddRange(asesores);
                context.SaveChanges();
            }
        }

        public Asesor AccesoAsesor(int _codigoAsesor, string _password)
        {
            using (var context = new ApiContext())
            {
                var asesor = context.Asesores
                    .Where(x => x.CodigoAsesor == _codigoAsesor && x.PasswordAsesor == _password).ToList().SingleOrDefault();
                return asesor;
            }
        }

        public List<Asesor> getAsesores()
        {
            using (var context = new ApiContext())
            {
                var list = context.Asesores
                    .ToList();
                return list;
            }
        }

        
    }
}
