namespace CRUD
{
    public class Series : EntidadeBase
    {
      
        private Genero Genero { get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}

        private bool Excluido {get; set;}
        
        public Series(Genero genero, string titulo, string descricao, int ano, bool excluido) 
        {
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = excluido;
        }

        
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero " + this.Genero + Environment.NewLine;
            retorno += "Titulo " + this.Titulo + Environment.NewLine;
            retorno += "Descrição " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio " + this.Ano + Environment.NewLine;
            return retorno;
        }

        
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        internal int retornaId()
        {
            return this.Id;
        }

        public void Exclui()
        {
            this.Excluido = true;
        }
    }

}