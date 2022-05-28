using Parcial.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial.Interfases
{
    public interface ICiudadDollar
    {
    }
    public interface IEgresos_Varios : IGastos, IPublicidad
    {

    }

    public interface IGastos
    {
        void Gastos(Ingresos_Egresos egresos);
    }
    public interface IPublicidad
    {
        void Publi(Ingresos_Egresos egresos);
    }
    public interface ICajaChica
    {
        void Caja(Ingresos_Egresos ingresos);
    }
}
