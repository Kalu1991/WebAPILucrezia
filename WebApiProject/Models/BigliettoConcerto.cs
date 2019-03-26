using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class BigliettoConcerto
    {
        public int ID { get; set; }
        public int Prezzo { get; set; }
        public bool Disponibile { get; set; }
        public string Artista { get; set; }
    }
}
