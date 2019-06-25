using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario luana;
        private Usuario alberto;

        [SetUp]
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();

            this.joao = new Usuario("Joao");
            this.luana = new Usuario("Luana");
            this.alberto = new Usuario("Alberto");
        }

        [Test]
        public void DeveEntenderLanceEmOrdemCrescente()
        {
            CriaAvaliador();
            Leilao leilao = new CriadorDeLeilao().Para("PlayStation 3")
                .Lance(luana, 250)
                .Lance(joao, 300)
                .Lance(alberto, 400)
                .Constroi();

            //CriaAvaliador();
            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
        }

        [Test]
        public void DeveEntenderLanceEmOrdemCrescenteComOutrosValores()
        {
            CriaAvaliador();
            Leilao leilao = new CriadorDeLeilao().Para("PlayStation 3")
                .Lance(luana, 2500)
                .Lance(joao, 4000)
                .Lance(alberto, 1000)
                .Constroi();

            //CriaAvaliador();
            leiloeiro.Avalia(leilao);

            double maiorEsperado = 4000;
            double menorEsperado = 1000;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
        }

        [Test]
        public void DeveEntenderLanceEmUmUnicoLance()
        {
            CriaAvaliador();
            Leilao leilao = new CriadorDeLeilao().Para("PlayStation 3")
                .Lance(luana, 2500)
                .Constroi();

            //CriaAvaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(2500, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(2500, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            CriaAvaliador();
            Leilao leilao = new CriadorDeLeilao().Para("PlayStation 4")
                .Lance(luana, 200)
                .Lance(alberto, 300)
                .Lance(luana, 400)
                .Lance(alberto, 500)
                .Constroi();

            //CriaAvaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count, 0.0001);
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
            CriaAvaliador();

            Leilao leilao = new CriadorDeLeilao().Para("Xbox One").Constroi();

            leiloeiro.Avalia(leilao);
        }
    }
}
