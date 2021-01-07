using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Model
{
    public class Carnívoro : Animal
    {
        
        public override double CalcularAlimento()
        {
            var total = 0D;
            total = total + Peso * Porcentaje;
            return total;
        }

        public override (double total, string comida) CalcularConsumoMensual()
        {
            var total = 0D;
            var comida = "";
            total = 30 * CalcularAlimento();
            comida = "Carne";
            return (total, comida);
        }
    }
}
