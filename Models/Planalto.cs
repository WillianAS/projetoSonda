using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSonda.Models
{
    public class Planalto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em X deve ser maior que zero")]
        public int tamanhoX { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "A coordenada em Y deve ser maior que zero")]
        public int tamanhoY { get; set; }

        public List<Sonda> sondas { get; set; }

        public bool ehRetangular (Planalto planalto)
        {
            return (planalto.tamanhoX == planalto.tamanhoY) ? false : true;
        }

        /*  TODO
        *   - ATUALIZAR MATRIZ PLANALTO
        */
    }
}