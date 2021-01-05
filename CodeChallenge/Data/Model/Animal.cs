namespace CodeChallenge.Data.Model
{
    public class Animal
    {
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public double Porcentaje { get; set; }
        public double Kilos { get; set; }
        public int Periodo { get; set; }



        public double CalcularAlimento()
        {
            var total = 0D;
            if (Tipo == "Carnívoro")
            {
                total = total + Peso * Porcentaje;
            }
            else if (Tipo == "Herbívoro")
            {
                total = total + (2 * Peso) + Kilos;
            }
            else if (Tipo == "Reptil")
            {
                total = total + (Peso * Porcentaje)/7;
            }
            return total;
        }

        public (double total, string comida) CalcularConsumoMensual()
        {
            var total = 0D;
            var comida = "";
            if (Tipo == "Carnívoro")
            {
                total = 30 * CalcularAlimento();
                comida = "Carne";
            }
            else if (Tipo == "Herbívoro")
            {
                total = 30 * CalcularAlimento();
                comida = "Hierba";
            }
            else if (Tipo == "Reptil")
            {
                
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
            }
            return (total,comida);
        }
        

    }
}