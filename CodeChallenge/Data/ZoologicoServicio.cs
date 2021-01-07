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
        public List<string> TiposAnimales => new List<string>() { "Carnívoro", "Herbívoro", "Reptil" };

        public bool AgregarAnimal(Animal animal)
        {
            DefinirTipo(animal);
            _animales.Add(_Animal);
            return true;
        }

        private void DefinirTipo(Animal animal)
        {
            if (animal.Tipo == "Carnívoro")
            {
                Carnívoro car = (Carnívoro)animal;
                _Animal = car;
            }
            else if (animal.Tipo == "Herbívoro")
            {
                Herbívoro her = (Herbívoro)animal;
                _Animal = her;
            }
            else if (animal.Tipo == "Reptil")
            {
                Reptil rep = (Reptil)animal;
                _Animal = rep;
            }
        }

        public void Confirmar(bool condicion)
        {
            if (condicion)
            {
                DefinirTipo(_Animal);
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

        public bool ValidarAnimal(Animal animal)
        {
            if (animal.Especie == null
                || animal.Tipo == null
                || animal.Edad <= 0
                || animal.LugarOrigen == null
                || animal.Peso <= 0)
            {
                return false;
            }
            if (animal.Tipo == "Herbívoro"
                && animal.Kilos <= 0)
            {
                return false;
            }
            if (animal.Tipo == "Carnívoro"
                && (animal.Porcentaje <= 0 || animal.Porcentaje > 1))
            {
                return false;
            }
            if (animal.Tipo == "Reptil"
                && (animal.Porcentaje <= 0 || animal.Porcentaje > 1 || animal.Periodo <= 0))
            {
                return false;
            }


            return true;
        }
    }
}
