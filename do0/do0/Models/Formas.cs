using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace do0.Models
{
    public class Formas
    {
        [Key]
        public int FormasId { get; set; }
        public string NomeForma { get; set; }
        public Tipo TipoForma { get; set; }

        public string Cor { get; set; }
        public int TamanhoPixels { get; set; }

        public int DiretorioId { get; set; }
        public virtual Diretorio DiretorioItem { get; set; }
    }

    public enum Tipo : int
    {
        Quadrado = 1,
        Triangulo = 2
    };

    public class FormasTipo
    {
        public int TipoId { get; set; }
        public string NomeTipo { get; set; }
    }
}