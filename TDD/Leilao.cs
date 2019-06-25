using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Leilao
    {
        public string Descricao { get; set; }

        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if (Lances.Count == 0 || podeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        private bool podeDarLance(Usuario usuario)
        {
            return (!ultimoLanceDado().Usuario.Equals(usuario) && qtdDeLances(usuario) < 5);
        }

        private int qtdDeLances(Usuario usuario)
        {
            int total = 0;

            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance ultimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}
