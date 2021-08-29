using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace do0.Models
{
    public class Diretorio
    {
        [Key]
        public int DiretorioId { get; set; }
        public string NomeDiretorio { get; set; }

        public IEnumerable<Formas> FormasLst { get; set; }
    }
}