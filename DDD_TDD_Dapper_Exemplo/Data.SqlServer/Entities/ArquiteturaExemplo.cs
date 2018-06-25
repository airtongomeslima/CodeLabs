namespace API.Data.SqlServer.Entities
{
    public class ArquiteturaExemplo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ArquiteturaExemplo() { }

        public ArquiteturaExemplo(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public ArquiteturaExemplo(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public bool ValidarNovoCadastro()
        {
            return true;
        }

        public bool ValidarAtualizacaoDoExemplo()
        {
            return true;
        }
    }
}
