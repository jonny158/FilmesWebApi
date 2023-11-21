using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Domain.Entities
{
    public class Locacao
    {
        public int Id { get; set; }
        public virtual ICollection<Filme> ListFilmes { get; set; }
        public string Cpf { get; set; }
        public DateTime DataLocacao { get; set; }

    }
}
