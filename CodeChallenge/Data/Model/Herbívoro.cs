using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Model
{
    public class Herbívoro : Animal
    {

        public override double CalcularAlimento()
        {
            var total = 0D;
            total = total + (2 * Peso) + Kilos;
            return total;
        }

        public override (double total, string comida) CalcularConsumoMensual()
        {
            var total = 0D;
            var comida = "";
            total = 30 * CalcularAlimento();
            comida = "Hierba";
            return (total, comida);
        }
    }
}
