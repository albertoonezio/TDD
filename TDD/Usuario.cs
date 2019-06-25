using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Usuario
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public Usuario(string nome) : this(0, nome)
        {

        }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != obj.GetType())
            {
                return false;
            }

            Usuario outroUsuario = (Usuario)obj;
            return outroUsuario.Id == this.Id && outroUsuario.Nome.Equals(this.Nome);
        }
    }
}
