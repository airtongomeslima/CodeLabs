using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateProjectDDDUoW.Models
{
    public class Contexto
    {
        public string Nome { get; set; }
        public string StringConexao { get; set; }
        public List<string> Tabelas { get; set; }
        public List<string> TabelasSelecionadas { get; set; }
        public object StringConexaoNome { get; internal set; }
    }
}
