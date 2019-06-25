using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private List<Lance> maioresLances;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
            {
                throw new Exception("Não eh possível avaliar um leilão sem lances");
            }

            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }

                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
            }

            pegaOsMaiores(leilao);
        }

        private void pegaOsMaiores(Leilao leilao)
        {
            maioresLances = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maioresLances = maioresLances.GetRange(0, maioresLances.Count > 3 ? 3 : maioresLances.Count);
        }

        public List<Lance> TresMaiores
        {
            get { return this.maioresLances; }
        }

        public double MaiorLance
        {
            get { return maiorDeTodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos; }
        }
    }
}
