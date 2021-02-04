using System.Collections.Generic;

namespace ProjetoSonda.Models
{
    public class Coordenadas 
    {
        public Planalto planalto { get; set; }
        
        public List<Sonda> Sondas { get; set; } 
    }
}