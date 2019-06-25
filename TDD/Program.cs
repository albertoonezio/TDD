using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usuario joao = new Usuario("Joao");
            //Usuario jose = new Usuario("Jose");
            //Usuario maria = new Usuario("Maria");

            //Leilao leilao = new Leilao("PlayStation 3");

            //leilao.Propoe(new Lance(maria, 250.0));
            //leilao.Propoe(new Lance(joao, 300.0));
            //leilao.Propoe(new Lance(jose, 400.0));

            //Avaliador leiloeiro = new Avaliador();
            //leiloeiro.Avalia(leilao);

            //double maiorEsperado = 400;
            //double menorEsperado = 250;
            //Console.WriteLine(maiorEsperado == leiloeiro.MaiorLance);
            //Console.WriteLine(menorEsperado == leiloeiro.MenorLance);

            //Console.ReadKey();

            TesteDoAvaliador avaliador = new TesteDoAvaliador();
            avaliador.DeveEntenderLanceEmOrdemCrescente();
            avaliador.DeveEntenderLanceEmOrdemCrescenteComOutrosValores();
            avaliador.DeveEntenderLanceEmUmUnicoLance();
            avaliador.DeveEncontrarOsTresMaioresLances();

            LeilaoTest testeLeilao = new LeilaoTest();
            testeLeilao.DeveReceberUmLance();
            testeLeilao.DeveReceberVariosLances();
        }
    }
}
