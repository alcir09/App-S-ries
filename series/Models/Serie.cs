using series.Enum;

namespace series.Models
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private String Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano){

            this.Id        = id;
            this.Genero    = genero;
            this.Titulo    = titulo;
            this.Descricao = descricao;
            this.Ano       = ano;
        } 

        //MÉTODOS
        public override string ToString()
        {   
            string retorno = "";
            retorno += "Genêro: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano início: " + this.Ano + Environment.NewLine;

            return retorno;
        }

        public string RetornaTitulo(){

            return this.Titulo;
        }

        public int RetornaId(){

            return this.Id;
        }

    }
}