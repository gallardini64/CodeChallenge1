namespace CodeChallenge.Data.Model
{
    public abstract class Animal
    {
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public int Periodo { get; set; }
        public double Porcentaje { get; set; }
        public double Kilos { get; set; }


        public abstract double CalcularAlimento();

        public abstract (double total, string comida) CalcularConsumoMensual();
        
        

    }
}