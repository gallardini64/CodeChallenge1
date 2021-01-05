using CodeChallenge.Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;

        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
        }

        [Test]
        public void CalcularAlimentoSinAnimales()
        {
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 22.5);
        }

        [Test]
        public void CalcularAlimentoSoloReptiles()
        {
            _animales.AddRange(MockFactoryReptiles());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void CalcularAlimentoSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 185);
        }

        [Test]
        public void CalcularAlimentoTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 217.5);
        }

        [Test]
        public void CalcularConsumoMensualCarnivoro()
        {
            _animales.Add(MockFactoryCarnivoros().FirstOrDefault());
            var result = _animales.Sum(a => a.CalcularConsumoMensual().total);
            Assert.AreEqual(result, 150);
        }

        [Test]
        public void CalcularConsumoMensualHerbivoro()
        {
            _animales.Add(MockFactoryHerivboros().FirstOrDefault());
            var result = _animales.Sum(a => a.CalcularConsumoMensual().total);
            Assert.AreEqual(result, 2100);
        }

        [Test]
        public void CalcularConsumoMensualReptil()
        {
            _animales.Add(MockFactoryReptiles().FirstOrDefault());
            var result = _animales.Sum(a => a.CalcularConsumoMensual().total);
            Assert.AreEqual(result, 210);
        }

        [Test]
        public void ConteoConsumoComidasCarnes()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Where(a => a.CalcularConsumoMensual().comida == "Carne").Sum(a => a.CalcularConsumoMensual().total);
            Assert.AreEqual(result, 675);
        }

        [Test]
        public void ConteoConsumoComidasHierbas()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales.Where(a => a.CalcularConsumoMensual().comida == "Hierba").Sum(a => a.CalcularConsumoMensual().total);
            Assert.AreEqual(result, 5550);
        }



        #region Mock Factory
        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 95,
                    Porcentaje = 0.1
                }
            };
        }

        private List<Animal> MockFactoryReptiles()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Reptil",
                    Peso = 700,
                    Porcentaje = 0.1,
                    Periodo = 7
                }
            };
        }

        private List<Animal> MockFactoryHerivboros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Herb�voro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Herb�voro",
                    Peso = 50,
                    Kilos = 15
                }
            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Carn�voro",
                    Peso = 95,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = "Herb�voro",
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = "Herb�voro",
                    Peso = 50,
                    Kilos = 15
                },
                new Animal{
                    Tipo = "Reptil",
                    Peso = 700,
                    Porcentaje = 0.1,
                    Periodo = 7
                }
            };
        }
        #endregion
    }
}