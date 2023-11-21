using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmes.Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
        public int IdGenero { get; set; }
        public virtual Genero Genero { get; set; }

    }
}
