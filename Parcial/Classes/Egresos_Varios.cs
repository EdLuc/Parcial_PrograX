using Parcial.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Classes
{
    public class Egresos_Varios : IEgresos_Varios
    {
        private IGastos gastos;
        private IPublicidad publicidad;
        public Egresos_Varios(IGastos gastos, IPublicidad publicidad)
        {
            if (gastos == null)
            {
                throw new ArgumentNullException(paramName: nameof(gastos));
            }
            this.gastos = gastos;
            this.publicidad = publicidad;
        }
        public void Gastos(Ingresos_Egresos egresos)
        {
            gastos.Gastos(egresos);
        }

        public void Publi(Ingresos_Egresos egresos)
        {
            publicidad.Publi(egresos);
        }
    }
}
