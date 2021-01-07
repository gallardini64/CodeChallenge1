using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Model
{
    public class Reptil : Animal
    {
        public override double CalcularAlimento()
        {
            var total = 0D;
            total = total + (Peso * Porcentaje) / 7;
            return total;
        }

        public override (double total, string comida) CalcularConsumoMensual()
        {
            var total = 0D;
            var comida = "";
            var periodo = Periodo;
            for (int i = 1; i <= 30; i++)
            {
                if (i == periodo)
                {
                    i += 3;
                    periodo += Periodo + 3;
                }
                total += CalcularAlimento();
            }
            comida = "Ambas";
            return (total, comida);
        }
    }
}
