using CodeChallenge.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        public List<Animal> _animales;
        public Animal _Animal { get; set; }
        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }
        public List<string> TiposAnimales => new List<string>() {"Carnívoro", "Herbívoro", "Reptil"};

        public bool AgregarAnimal(Animal animal)
        {
            _Animal = animal;
            _animales.Add(_Animal);
            return true;
        }

        public void Confirmar(bool condicion)
        {
            if (condicion)
            {
                    _animales.Add(_Animal);
            }
            else
            {
                _Animal = null;
            }
        }
        public List<Animal> ObtenerAnimales()
        {
            return _animales;
        }

        public (double carne, double hierba) ObtenerConsumoComidaMensual()
        {
            var carnes = 0D;
            var hierbas = 0D;

            foreach (var animal in _animales)
            {
                var tupla = animal.CalcularConsumoMensual();
                if (tupla.comida == "Carne")
                {
                    carnes += tupla.total;
                }
                else if (tupla.comida == "Hierba")
                {
                    hierbas += tupla.total;
                }
                else if (tupla.comida == "Ambas")
                {
                    carnes += tupla.total / 2;
                    hierbas += tupla.total / 2;
                }
            }

            return (carnes, hierbas);
        }
    }
}
